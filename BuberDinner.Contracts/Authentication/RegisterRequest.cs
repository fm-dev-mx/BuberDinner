namespace BuberDinner.Contracts.Authentication;

// Record used to capture all necessary information from users during the registration process.
// This data structure collects user details that are essential for creating a new user account in the system.
public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password
);