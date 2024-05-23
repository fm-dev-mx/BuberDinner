using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register;

// Defines a CQRS command for registering a new user as part of the authentication process.
public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;

// Implements IRequest from MediatR. This CQRS pattern expects a response
// wrapped in ErrorOr that indicates either the successful creation of an AuthenticationResult
// or provides error details.