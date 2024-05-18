using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

// Represents a rating value object with a specific integer value.
// Designed as a value object to ensure immutability and to provide value-based equality.
public sealed class Rating : ValueObject
{
    // The rating value. This property is read-only and ensures immutability.
    public int Value { get; }

    // Private constructor to enforce the use of the Create factory method for instantiation.
    private Rating(int value)
    {
        Value = value;
    }

    // Factory method to create a new Rating.
    public static Rating Create(int value)
    {
        // TODO: Enforce invariants such as valid value (e.g., between 1 and 5).
        return new Rating(value);
    }

    // Overrides the GetEqualityComponents method to define the components that are used for equality comparison.
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}