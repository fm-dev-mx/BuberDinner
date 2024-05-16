using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

// Represents an item in the menu, characterized by its name and description.
// This entity is uniquely identified by a MenuItemId.
public sealed class MenuItem : Entity<MenuItemId>
{
    // The name of the menu item.
    public string Name { get; }

    // The description of the menu item.
    public string Description { get; }

    // Private constructor to initialize the MenuItem with a unique identifier, name, and description.
    // The constructor is private to enforce the use of the Create factory method for instantiation.
    private MenuItem(MenuItemId menuItemId, string name, string description)
        : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

    // Factory method to create a new MenuItem with a unique identifier.
    // This method ensures that each MenuItem is instantiated with a unique MenuItemId.
    public static MenuItem Create(string name, string description)
    {
        // Creates a new MenuItem instance using a unique MenuItemId, name, and description.
        return new MenuItem(MenuItemId.CreateUnique(), name, description);
    }
}