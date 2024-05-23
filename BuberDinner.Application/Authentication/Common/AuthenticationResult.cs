using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Application.Authentication.Common;

// Defines a record for holding the result of an authentication operation.
// This record is used to encapsulate the outcome of a login or registration process.
public record AuthenticationResult(
    User User,   // The User object representing the authenticated user.
    string Token); // The JWT token generated for the user upon successful authentication.