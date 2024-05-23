using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

// Represents a section within a menu, which includes a collection of menu items.
// Each MenuSection is uniquely identified by a MenuSectionId and acts as an aggregate root.
public sealed class MenuSection : Entity<MenuSectionId>
{
    // A list of menu items within this section. This list is mutable internally but exposed as read-only externally.
    private readonly List<MenuItem> _items = new();

    // The name of the menu section.
    public string Name { get; }

    // The description of the menu section.
    public string Description { get; }

    // Provides read-only access to the menu items in this section.
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    // Private constructor to initialize the MenuSection with a unique identifier, name, and description.
    // The constructor is private to enforce the use of the Create factory method for instantiation.
    private MenuSection(string name, string description, List<MenuItem> items, MenuSectionId? id = null)
        : base(id ?? MenuSectionId.Create(name))
    {
        Name = name;
        Description = description;
        _items = items;
    }

    // Factory method to create a new MenuSection with a unique identifier.
    // This method ensures that each MenuSection is instantiated with a unique MenuSectionId.
    // It also allows optional initialization of menu items.
    public static MenuSection Create(string name, string description, List<MenuItem>? items = null)
    {
        // Ensures a new MenuSection is created with the provided name, description, and optional items.
        return new MenuSection(name, description, items ?? new());
    }
}