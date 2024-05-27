using FluentValidation;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

// Validator for CreateMenuCommand to enforce validation rules.
// This class is used to validate the CreateMenuCommand before it is processed by the command handler.
public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        // Ensures that the Name property is not empty.
        RuleFor(x => x.Name).NotEmpty();

        // Ensures that the Description property is not empty.
        RuleFor(x => x.Description).NotEmpty();

        // Ensures that the Sections property is not empty.
        RuleFor(x => x.Sections).NotEmpty();
    }
}