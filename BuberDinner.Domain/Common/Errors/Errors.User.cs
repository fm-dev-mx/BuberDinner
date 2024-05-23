using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

// Partial static class that facilitates the distributed definition of error types across multiple files,
// enabling scalable and organized expansion of error handling logic.
public static partial class Errors
{
    // Nested static class specifically for errors related to user management.
    public static class User
    {
        // Property representing an error that occurs when an attempt is made to register
        // a user with an email address that already exists in the database.
        // This error type is used to signal a conflict in the system, indicating that the action cannot be completed
        // as it would violate the uniqueness constraint of email addresses.
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail", // Unique error code that can be used for identifying the error type in client-side logic or logs.
            description: "Email already exists"); // Descriptive message that explains the nature of the error to the end-user or developer.
    }
}