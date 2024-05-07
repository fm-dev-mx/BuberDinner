using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infrastructure.Services;

// Implements the IDateTimeProvider interface to provide a centralized way to access the current UTC time.
// This class helps in decoupling components from direct dependencies on system time, which enhances testability and flexibility.
public class DateTimeProvider : IDateTimeProvider
{
    // Gets the current UTC date and time.
    // This property is essential for operations that depend on the current date and time,
    // such as setting token expiry, logging, and other time-sensitive functionalities.
    public DateTime UtcNow => DateTime.UtcNow;
}