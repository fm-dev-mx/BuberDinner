using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

// Endpoints for user authentication.
// The authentication process involves registering a new user or logging in with an existing account.
[Route("auth")]

// Allows anonymous access to authentication endpoints.
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    // Dependency injection for MediatR and Mapster interfaces.
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // HTTP POST method for user registration.
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        // Map the DTO to the RegisterCommand for MediatR handling.
        var command = _mapper.Map<RegisterCommand>(request);

        // Send command to MediatR and wait for a result, which is either an AuthenticationResult or a list of errors.
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        // Handle the result: if successful, map the result to a response DTO and return an OK status; if failed, return a problem detail.
        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

    // HTTP POST method for user login.
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        // Map the DTO to the LoginQuery for MediatR handling.
        var query = _mapper.Map<LoginQuery>(request);

        // Send query to MediatR and wait for a result.
        var authResult = await _mediator.Send(query);

        // Special error handling for invalid credentials.
        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);
        }

        // Handle the result: if successful, map the result to a response DTO and return an OK status; if failed, return a problem detail.
        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}