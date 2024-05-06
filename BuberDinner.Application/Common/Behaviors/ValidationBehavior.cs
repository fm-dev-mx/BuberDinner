using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BuberDinner.Application.Common.Behaviors;

// Defines a MediatR pipeline behavior that systematically validates each request against expected response criteria,
// ensuring that only requests meeting all validation checks are processed further in the system.
public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
{
    // Optional validation service, used if a validator for the request type is available.
    private readonly IValidator<TRequest>? _validator;

    // Constructor with an optional validator dependency.
    // The validator is provided via dependency injection if validation rules exist for the TRequest type.
    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    // Validates the incoming request asynchronously and, if valid, passes it to the subsequent handler in the MediatR pipeline.
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // If no validator is set, bypass validation and forward the request directly to the next delegate.
        if (_validator is null) return await next();

        // Validate the request, capturing the result to determine the next steps in the request handling pipeline.
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        // If validation is successful, proceed to the next delegate in the pipeline.
        if (validationResult.IsValid) return await next();

        // When validation is unsuccessful, transform each validation failure into an Error object
        // and aggregate these into a dynamic ErrorOr collection for consistent error handling.
        var errors = validationResult.Errors
            .ConvertAll(ValidationFailure => Error.Validation(
                ValidationFailure.PropertyName,
                ValidationFailure.ErrorMessage))
            .ToList();

        /*
           **Why `dynamic` is used:**
           * `Dynamic` is utilized here to return types that comply with the `IErrorOr` interface,
           * even though they may not be the exact `TResponse` type.
           * This allows for flexible handling of various error responses within the constraints of C#'s type system,
           * which is essential in architectures like CQRS and MediatR where responses might differ but adhere to a common interface.
        */
        return (dynamic)errors;
    }
}