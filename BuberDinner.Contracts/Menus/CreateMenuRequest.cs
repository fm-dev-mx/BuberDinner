namespace BuberDinner.Contracts.Menus;

// Represents a request to create a new menu, used by the API to receive menu details from the client.
public record CreateMenuRequest(
    string Name,                    // The name of the menu.
    string Description,             // The description of the menu.
    List<MenuSection> Sections);    // The sections of the menu, which include a collection of menu items.

// Represents a section within a menu, used in the CreateMenuRequest to structure the menu.
public record MenuSection(
    string Name,                    // The name of the section.
    string Description,             // The description of the section.
    List<MenuItem> Items);          // The collection of menu items in the section, if any.

// Represents an item within a menu section, used in the MenuSection record to list items.
public record MenuItem(
    string Name,                    // The name of the menu item.
    string Description);            // The description of the menu item.