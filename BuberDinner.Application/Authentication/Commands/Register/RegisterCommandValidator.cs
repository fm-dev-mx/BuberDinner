using FluentValidation;

namespace BuberDinner.Application.Authentication.Commands.Register;

// Defines a validator for RegisterCommand using the AbstractValidator<T> class from FluentValidation.
// This base class allows the creation of custom validation rules for objects, ensuring that RegisterCommand
// data adheres to specified standards before processing.
public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    // Constructor that initializes the RegisterCommandValidator by defining specific validation rules for each property.
    // These rules ensure that all inputs meet our application's requirements for data correctness and completeness.

    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email address is required.")
            .EmailAddress().WithMessage("Email address is not valid.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
    }
}