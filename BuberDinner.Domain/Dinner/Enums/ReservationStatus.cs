using Ardalis.SmartEnum;

namespace BuberDinner.Domain.Dinner.Enums;

// Defines the status of a reservation as a smart enumeration using the Ardalis SmartEnum library.
// This implementation enhances the standard enum by allowing each status to encapsulate additional logic and properties
public class ReservationStatus : SmartEnum<ReservationStatus>
{
    // Private constructor to initialize the ReservationStatus with a name and value.
    // This constructor is private to enforce the use of the predefined static instances.
    public ReservationStatus(string name, int value) : base(name, value)
    {
    }

    // Represents a reservation that is pending guest approval.
    public static readonly ReservationStatus PendingGuestApproval = new(nameof(PendingGuestApproval), 1);

    // Represents a reservation that has been confirmed and reserved.
    public static readonly ReservationStatus Reserved = new(nameof(Reserved), 2);

    // Represents a reservation that has been cancelled.
    public static readonly ReservationStatus Cancelled = new(nameof(Cancelled), 3);
}
