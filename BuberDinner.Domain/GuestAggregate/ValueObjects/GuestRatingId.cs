using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;

// Represents a unique identifier for a guest rating.
// This value object ensures that each guest rating can be uniquely identified and provides value-based equality.
public sealed class GuestRatingId : ValueObject
{
    // The actual string value representing the guest rating ID.
    public string Value { get; }

    // Private constructor to enforce the use of the factory methods for instantiation.
    // This constructor directly accepts a pre-generated guest rating ID value.
    private GuestRatingId(string value) => Value = value;

    // Private constructor to enforce the use of the factory methods for instantiation.
    // This constructor generates a guest rating ID based on the provided dinner and host IDs.
    private GuestRatingId(DinnerId dinnerId, HostId hostId) => Value = $"Rating_{dinnerId.Value}_{hostId.Value}";

    // Factory method to create a new GuestRatingId from dinner and host IDs.
    // This method generates a guest rating ID by combining the dinner and host IDs.
    public static GuestRatingId Create(DinnerId dinnerId, HostId hostId) => new(dinnerId, hostId);

    // Factory method to create a new GuestRatingId from a pre-generated value.
    // This method allows creating a GuestRatingId with an existing ID value.
    public static GuestRatingId Create(string value) => new(value);

    // Overrides the GetEqualityComponents method to define the components that are used for equality comparison.
    // In this case, the Value property is the sole component that determines equality.
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}