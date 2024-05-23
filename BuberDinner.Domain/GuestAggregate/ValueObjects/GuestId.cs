using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;

// Represents a unique identifier for a guest.
// This value object ensures that each guest can be uniquely identified and provides value-based equality.
public sealed class GuestId : ValueObject
{
    // The actual string value representing the GuestId.
    public string Value { get; }

    // Private constructor to enforce the use of the factory methods for instantiation.
    // This constructor generates a guest ID based on the provided user ID.
    private GuestId(UserId userId) => Value = $"Guest_{userId.Value}";

    // Private constructor to enforce the use of the factory methods for instantiation.
    // This constructor directly accepts a pre-generated guest ID value.
    private GuestId(string userId) => Value = userId;

    // Overrides the GetEqualityComponents method to define the components that are used for equality comparison.
    // In this case, the Value property is the sole component that determines equality.
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    // Factory method to create a new GuestId from a UserId.
    // This method generates a guest ID by prefixing "Guest_" to the provided user ID.
    public static GuestId Create(UserId userId) => new(userId);

    // Factory method to create a new GuestId from a pre-generated value.
    // This method allows creating a GuestId with an existing ID value.
    public static GuestId Create(string userId) => new(userId);
}