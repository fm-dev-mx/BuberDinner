using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;

// Class that handles login queries using MediatR. It processes login attempts and returns an authentication result.
public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator; // Service for generating JWT tokens.
    private readonly IUserRepository _userRepository;       // Repository for accessing user data.

    // Constructor to inject dependencies needed for token generation and user data retrieval.
    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    // Method to handle the login request. Implements MediatR's IRequestHandler.
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // Temporarily fulfills the async method signature.
        await Task.CompletedTask;

        // 1. Validate the user exists
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            // Return an error if the email does not correspond to a registered user.
            return Errors.Authentication.InvalidCredentials;
        }

        // 2. Validate the password is correct
        if (user.Password != query.Password)
        {
            // Return an error if the password does not match the user's stored password.
            return Errors.Authentication.InvalidCredentials;
        }

        // 3. Generate a JWT token for the authenticated user.
        var token = _jwtTokenGenerator.GenerateToken(user);

        // Return a successful authentication result containing the user and the new JWT token.
        return new AuthenticationResult(
            user,
            token);
    }
}