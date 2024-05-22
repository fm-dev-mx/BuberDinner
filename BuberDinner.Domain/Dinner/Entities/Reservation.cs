using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Enums;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities;

// Represents a reservation for a dinner event.
// This entity contains details about the reservation, such as the associated dinner, guest, status, and timestamps.
public sealed class Reservation : Entity<ReservationId>
{
    // The ID of the dinner associated with this reservation.
    public DinnerId DinnerId { get; }
    // The number of guests included in this reservation.
    public int GuestCount { get; }
    // The ID of the guest who made the reservation.
    public GuestId GuestId { get; }
    // The ID of the bill associated with this reservation.
    public BillId BillId { get; }
    // The status of the reservation (e.g., confirmed, cancelled).
    public ReservationStatus Status { get; }
    // The date and time when the guests are expected to arrive. Nullable if arrival time is not specified.
    public DateTime? ArrivalDateTime { get; }
    // The date and time when the reservation was created.
    public DateTime CreatedDateTime { get; } = DateTime.UtcNow;
    // The date and time when the reservation was last updated.
    public DateTime UpdatedDateTime { get; } = DateTime.UtcNow;

    // Private constructor to enforce the use of the Create factory method.
    private Reservation(
        DinnerId dinnerId,
        GuestId guestId,
        int guestCount,
        DateTime? arrivalDateTime,
        BillId billId,
        ReservationStatus status)
        : base(ReservationId.Create(dinnerId, guestId)) // Generate ReservationId from dinnerId and guestId
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        GuestCount = guestCount;
        ArrivalDateTime = arrivalDateTime;
        BillId = billId;
        Status = status;
    }

    // Factory method to initializes a Reservation with the provided details and optional bill ID and arrival time.
    public static Reservation Create(
        DinnerId dinnerId,
        GuestId guestId,
        int guestCount,
        ReservationStatus status,
        BillId? billId = null,
        DateTime? arrivalDateTime = null)
    {
        // Ensure BillId is not null, if not provided, default to a new BillId.
        return new Reservation(
            dinnerId,
            guestId,
            guestCount,
            arrivalDateTime,
            billId ?? BillId.Create(dinnerId,guestId), // Create a new BillId if not provided
            status
        );
    }
}
