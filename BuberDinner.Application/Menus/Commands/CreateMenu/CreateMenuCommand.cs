using BuberDinner.Domain.MenuAggregate;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

// Command to create a new menu, used by the application layer when a host initiates the creation of a new menu via an API endpoint.
public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;

// Represents a section within the menu, used by the CreateMenuCommand to define the structure of a menu's sections.
public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> Items);

// Represents an item within a menu section, used by the MenuSectionCommand to detail individual items within a section.
public record MenuItemCommand(
    string Name,
    string Description);