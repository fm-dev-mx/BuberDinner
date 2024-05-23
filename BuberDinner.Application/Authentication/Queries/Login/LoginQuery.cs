using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;

// Defines a CQRS query record for handling login requests, encapsulating the necessary user credentials.
public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;

// Implements IRequest from MediatR for CQRS pattern handling,
// this CQRS pattern expects an ErrorOr wrapped AuthenticationResult
// indicating the login success or error types.