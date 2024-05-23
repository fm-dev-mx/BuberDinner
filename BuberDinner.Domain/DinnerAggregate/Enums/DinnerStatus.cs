using Ardalis.SmartEnum;

namespace BuberDinner.Domain.DinnerAggregate.Enums;

// Defines the status of a dinner event as a smart enumeration using the Ardalis SmartEnum library.
// This implementation enhances the standard enum by allowing each status to encapsulate additional logic and properties
public class DinnerStatus : SmartEnum<DinnerStatus>
{
    // Private constructor to initialize the DinnerStatus with a name and value.
    // This constructor is private to enforce the use of the predefined static instances.
    public DinnerStatus(string name, int value) : base(name, value)
    {
    }

    // Represents a dinner event that is scheduled to happen in the future.
    public static readonly DinnerStatus Upcoming = new(nameof(Upcoming), 1);

    // Represents a dinner event that is currently in progress.
    public static readonly DinnerStatus InProgress = new(nameof(InProgress), 2);

    // Represents a dinner event that has ended.
    public static readonly DinnerStatus Ended = new(nameof(Ended), 3);

    // Represents a dinner event that has been cancelled.
    public static readonly DinnerStatus Cancelled = new(nameof(Cancelled), 4);
}