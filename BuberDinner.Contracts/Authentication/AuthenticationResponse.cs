namespace BuberDinner.Contracts.Authentication;

// Record to represent the data structure for the response returned upon successful authentication.
// This response includes user-specific details along with an authentication token.
public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);