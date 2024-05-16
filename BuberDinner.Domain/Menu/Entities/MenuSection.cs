using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

// Represents a section within a menu, which includes a collection of menu items.
// Each MenuSection is uniquely identified by a MenuSectionId.
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
    private MenuSection(MenuSectionId menuSectionId, string name, string description)
        : base(menuSectionId)
    {
        Name = name;
        Description = description;
    }

    // Factory method to create a new MenuSection with a unique identifier.
    // This method ensures that each MenuSection is instantiated with a unique MenuSectionId.
    public static MenuSection Create(string name, string description)
    {
        // Creates a new MenuSection instance using a unique MenuSectionId, name, and description.
        return new MenuSection(MenuSectionId.CreateUnique(), name, description);
    }
}