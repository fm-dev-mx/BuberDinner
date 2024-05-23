using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

// Represents a unique identifier for a menu.
// This value object ensures that each menu can be uniquely identified and provides value-based equality.
public sealed class MenuId : ValueObject
{
    // The actual GUID value representing the menu ID.
    public Guid Value { get; }

    // Private constructor to enforce the use of the factory method for instantiation.
    private MenuId(Guid value)
    {
        Value = value;
    }

    // Factory method generates a new GUID to ensure that each MenuId is unique.
    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }

    // Provides the values that should be considered when comparing two instances of this value object.
    // For MenuId, the equality comparison is based solely on the Value property.
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}