namespace BuberDinner.Contracts.Authentication;

// Record to represent the login credentials submitted by a user.
// This data structure is used to pass the user's login details from the client to the server for authentication.
public record LoginRequest(
    string Email,
    string Password
);