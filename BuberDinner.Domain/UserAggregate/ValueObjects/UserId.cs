using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.UserAggregate.ValueObjects;

// Represents a unique identifier for a user.
// This value object ensures that each user can be uniquely identified and provides value-based equality.
public sealed class UserId : ValueObject
{
    // The actual GUID value representing the user ID.
    public Guid Value { get; }

    // Private constructor to enforce the use of factory methods for instantiation.
    // This constructor directly accepts a GUID value.
    private UserId(Guid value) => Value = value;

    // Factory method to create a new UserId with a unique GUID.
    // This method generates a new GUID to ensure that each UserId is unique.
    public static UserId CreateUnique() => new(Guid.NewGuid());

    // Factory method to create a new UserId with a specified GUID value.
    // This method allows creating a UserId with an existing GUID.
    public static UserId Create(Guid userId) => new(userId);

    // Overrides the GetEqualityComponents method to define the components that are used for equality comparison.
    // In this case, the Value property is the sole component that determines equality.
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}