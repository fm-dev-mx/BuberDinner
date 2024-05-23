using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

// Represents an item in the menu, characterized by its name and description.
// This entity is uniquely identified by a MenuItemId.
public sealed class MenuItem : Entity<MenuItemId>
{
    // The name of the menu item.
    public string Name { get; }

    // The description of the menu item.
    public string Description { get; }

    // Private constructor to enforce the use of the Create factory method for instantiation.
    private MenuItem(string name, string description)
        : base(MenuItemId.Create(name))
    {
        Name = name;
        Description = description;
    }

    // Factory method to create a new MenuItem with a unique identifier.
    // This method ensures that each MenuItem is instantiated with a unique MenuItemId.
    public static MenuItem Create(string name, string description)
    {
        // TODO: Add validation logic if necessary to ensure name and description are valid.
        return new MenuItem(name, description);
    }
}