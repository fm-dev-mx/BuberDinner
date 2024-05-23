using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

// Represents a unique identifier for a reservation.
// This value object ensures that each reservation can be uniquely identified and provides value-based equality.
public sealed class ReservationId : ValueObject
{
    // The actual string value representing the reservation ID.
    public string Value { get; }

    // Private constructor to enforce the use of the factory methods for instantiation.
    // This constructor generates a reservation ID based on the provided dinner and guest IDs.
    private ReservationId(DinnerId dinnerId, GuestId guestId)
    {
        Value = $"Reservation_{dinnerId.Value}_{guestId.Value}";
    }

    // Private constructor to enforce the use of the factory methods for instantiation.
    // This constructor directly accepts a pre-generated reservation ID value.
    private ReservationId(string value)
    {
        Value = value;
    }

    // Factory method to create a new ReservationId from dinner and guest IDs.
    // This method generates a reservation ID by combining the dinner and guest IDs.
    public static ReservationId Create(DinnerId dinnerId, GuestId guestId)
    {
        return new ReservationId(dinnerId, guestId);
    }

    // Factory method to create a new ReservationId from a pre-generated value.
    // This method allows creating a ReservationId with an existing ID value.
    public static ReservationId Create(string value)
    {
        return new ReservationId(value);
    }

    // Overrides the GetEqualityComponents method to define the components that are used for equality comparison.
    // In this case, the Value property is the sole component that determines equality.
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}