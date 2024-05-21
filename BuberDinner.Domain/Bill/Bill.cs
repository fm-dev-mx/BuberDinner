using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Bill;

// Represents a bill as an aggregate root within the domain model.
// Each Bill is uniquely identified by a BillId and encapsulates details about the dinner, guest, host, and amount.
public sealed class Bill : AggregateRoot<BillId>
{
    // The ID of the dinner associated with this bill.
    public DinnerId DinnerId { get; }
    // The ID of the guest associated with this bill.
    public GuestId GuestId { get; }
    // The ID of the host associated with this bill.
    public HostId HostId { get; }
    // The amount to be paid for the dinner.
    public Price Amount { get; }
    // The date and time the bill was created.
    public DateTime CreatedDateTime { get; }
    // The date and time the bill was last updated.
    public DateTime UpdatedDateTime { get; }

    // Private constructor to enforce the use of the Create factory method.

    private Bill(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price amount,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(BillId.Create(dinnerId, guestId)) // Generate BillId from dinnerId and guestId
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Amount = amount;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    // Factory method to create a new Bill.
    public static Bill Create(
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price amount)
    {
        // TODO: Enforce invariants such as valid amount (e.g., non-negative) and valid currency codes.
        return new Bill(
            dinnerId,
            guestId,
            hostId,
            amount,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}