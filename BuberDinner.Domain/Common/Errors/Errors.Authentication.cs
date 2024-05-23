using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

// Partial static class that facilitates the distributed definition of error types across multiple files,
// enabling scalable and organized expansion of error handling logic.
public static partial class Errors
{
    // Nested static class that encapsulates authentication-specific errors.
    public static class Authentication
    {
        // Property that represents an error for invalid credentials. This error is used
        // when authentication fails due to incorrect username or password.
        // 'InvalidCredentials' provides a standardized error code and message that can be
        // returned from API endpoints to indicate the specific nature of the authentication failure.
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCredentials", // Unique error code for identifying the error type.
            description: "Invalid credentials."); // Description that explains what the error is about.
    }
}