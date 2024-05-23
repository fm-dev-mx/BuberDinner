using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.BillAggregate.ValueObjects;

// Represents a unique identifier for a bill.
// This value object ensures that each bill can be uniquely identified and provides value-based equality.
public sealed class BillId : ValueObject
{
    // The actual string value representing the bill ID.
    public string Value { get; }

    // Private constructor to enforce the use of the factory methods for instantiation.
    // This constructor directly accepts a pre-generated bill ID value.
    private BillId(string value) => Value = value;

    // Private constructor to enforce the use of the factory methods for instantiation.
    // This constructor generates a bill ID based on the provided dinner and guest IDs.
    private BillId(DinnerId dinnerId, GuestId guestId)
    {
        Value = $"Bill_{dinnerId.Value}_{guestId.Value}";
    }

    // Factory method to create a new BillId from dinner and guest IDs.
    // This method generates a bill ID by combining the dinner and guest IDs.
    public static BillId Create(DinnerId dinnerId, GuestId guestId)
    {
        return new BillId(dinnerId, guestId);
    }

    // Factory method to create a new BillId from a pre-generated value.
    // This method allows creating a BillId with an existing ID value.
    public static BillId Create(string value)
    {
        return new BillId(value);
    }

    // Overrides the GetEqualityComponents method to define the components that are used for equality comparison.
    // In this case, the Value property is the sole component that determines equality.
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}