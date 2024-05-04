using System.Diagnostics;
using BuberDinner.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace BuberDinner.Api.Common.Errors;

public class BuberDinnerProblemDetailsFactory : ProblemDetailsFactory
{
    private readonly ApiBehaviorOptions _options;

    // Constructor that initializes the factory with API behavior options.
    public BuberDinnerProblemDetailsFactory(IOptions<ApiBehaviorOptions> options)
    {
        // Throw an exception if options are not provided, ensuring non-null configuration settings.
        _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
    }

    // Override the base method to create general problem details based on provided parameters.
    public override ProblemDetails CreateProblemDetails(
        HttpContext httpContext,
        int? statusCode = null,
        string? title = null,
        string? type = null,
        string? detail = null,
        string? instance = null)
    {
        // Default status code is 500 if not specified.
        statusCode ??= 500;

        // Create and initialize a ProblemDetails object.
        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Detail = detail,
            Instance = instance,
        };

        // Apply default settings and additional properties to the problem details.
        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

        return problemDetails;
    }

    // Override the base method to create validation problem details from model state errors.
    public override ValidationProblemDetails CreateValidationProblemDetails(
        HttpContext httpContext,
        ModelStateDictionary modelStateDictionary,
        int? statusCode = null,
        string? title = null,
        string? type = null,
        string? detail = null,
        string? instance = null)
    {
        // Ensure modelStateDictionary is not null to prevent processing invalid requests.
        ArgumentNullException.ThrowIfNull(modelStateDictionary);

        // Default status code is 400 for validation errors.
        statusCode ??= 400;

        // Create and initialize a ValidationProblemDetails object with model state errors.
        var problemDetails = new ValidationProblemDetails(modelStateDictionary)
        {
            Status = statusCode,
            Type = type,
            Detail = detail,
            Instance = instance,
        };

        // Preserve a provided title, avoiding overwrite with null.
        if (title != null)
        {
            problemDetails.Title = title;
        }

        // Apply default settings and additional properties to the validation problem details.
        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

        return problemDetails;
    }

    // Helper method to apply default properties and custom behaviors to ProblemDetails objects.
    private void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
    {
        // Ensure a status code is set; use the provided statusCode if Status is null.
        problemDetails.Status ??= statusCode;

        // Apply default title and type from ApiBehaviorOptions if they are not set.
        if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
        {
            problemDetails.Title ??= clientErrorData.Title;
            problemDetails.Type ??= clientErrorData.Link;
        }

        // Add a trace identifier for tracking and debugging purposes.
        var traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
        if (traceId != null)
        {
            problemDetails.Extensions["traceId"] = traceId;
        }

        // Add error codes from HttpContext if available, useful for debugging and detailed error responses.
        var errors = httpContext?.Items[HttpContextItemKeys.Errors] as List<Error>;
        if(errors is not null)
        {
            problemDetails.Extensions.Add("errorCodes", errors.Select(e => e.Code));
        }
    }
}
