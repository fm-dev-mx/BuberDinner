namespace BuberDinner.Application.Common.Interfaces.Services;

// Interface defining a contract for obtaining the current date and time.
public interface IDateTimeProvider
{
    // Property to get the current UTC date and time.
    DateTime UtcNow { get; }
}
