using FluentValidation;

namespace BuberDinner.Application.Authentication.Queries.Login;

// Defines a validator for LoginQuery using the AbstractValidator<T> class from FluentValidation.
// This base class allows the creation of custom validation rules for objects, ensuring that LoginQuery
// data adheres to specified standards before processing.
public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    // Constructor initializes validation rules for LoginQuery properties,
    // ensuring required fields are present and correctly formatted.
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}