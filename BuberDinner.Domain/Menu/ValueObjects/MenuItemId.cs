using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

// Represents a unique identifier for a menu item.
// This value object ensures that each menu item can be uniquely identified and provides value-based equality.
public sealed class MenuItemId : ValueObject
{
    // The actual GUID value representing the menu item ID.
    public Guid Value { get; }

    // Private constructor to enforce the use of the factory method for instantiation.
    private MenuItemId(Guid value)
    {
        Value = value;
    }

    // Factory method generates a new GUID to ensure that each MenuItemId is unique.
    public static MenuItemId CreateUnique()
    {
        return new MenuItemId(Guid.NewGuid());
    }

    // Overrides the GetEqualityComponents method to define the components that are used for equality comparison.
    // In this case, the Value property is the sole component that determines equality.
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
