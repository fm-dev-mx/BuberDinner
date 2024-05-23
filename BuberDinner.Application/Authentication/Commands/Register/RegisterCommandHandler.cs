using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register;

// Class to handle registration commands using the MediatR library for CQRS pattern.
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    // Constructor injecting dependencies for token generation and user repository access.
    // Service to generate JWT for authentication.
    // Repository for user persistence operations.
    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    // Asynchronously handles the registration command following the CQRS pattern.
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        // Temporarily fulfills the async method signature.
        await Task.CompletedTask;

        // 1. Validate the user doesn't already exist based on their email.
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // 2. Create a new user entity and save it to the database.
        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password);

        _userRepository.Add(user);

        // 3. Generate a JWT token for the newly registered user.
        var token = _jwtTokenGenerator.GenerateToken(user);

        // Return successful authentication result including the user and their token.
        return new AuthenticationResult(
            user,
            token);
    }
}