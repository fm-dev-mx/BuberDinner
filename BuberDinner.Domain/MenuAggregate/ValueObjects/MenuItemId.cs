using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

// Represents a unique identifier for a menu item.
// This value object ensures that each menu item can be uniquely identified and provides value-based equality.
public sealed class MenuItemId : ValueObject
{
    // The actual string value representing the menu item ID.
    public string Value { get; }

    // Private constructor to enforce the use of the factory method for instantiation.
    private MenuItemId(string itemName)
    {
        Value = $"Item_{itemName}";
    }

    // Overrides the GetEqualityComponents method to define the components that are used for equality comparison.
    // In this case, the Value property is the sole component that determines equality.
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    // Factory method to create a new MenuItemId.
    // This method ensures that each MenuItemId is generated with a consistent format.
    public static MenuItemId Create(string itemName)
    {
        // TODO: Add validation logic if necessary to ensure itemName is valid.
        return new MenuItemId(itemName);
    }
}