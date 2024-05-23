using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;

// Represents a unique identifier for a host.
// This value object ensures that each host can be uniquely identified and provides value-based equality.
public sealed class HostId : ValueObject
{
    // The actual string value representing the host ID.
    public string Value { get; }

    // Private constructor to enforce the use of the factory methods for instantiation.
    // This constructor directly accepts a pre-generated host ID value.
    private HostId(string value) => Value = value;

    // Factory method to create a new HostId from a pre-generated ID value.
    // This method allows creating a HostId with an existing ID value.
    public static HostId Create(string hostId) => new(hostId);

    // Factory method to create a new HostId from a UserId.
    // This method generates a host ID by combining the prefix "Host_" with the UserId value.
    public static HostId Create(UserId userId) => new($"Host_{userId.Value}");

    // Overrides the GetEqualityComponents method to define the components that are used for equality comparison.
    // In this case, the Value property is the sole component that determines equality.
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}