using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.Api.Common.Mapping;

// Configures mappings between authentication-related DTOs and domain models.
// Utilizes Mapster for flexible and performant object mapping.
public class AuthenticationMappingConfig : IRegister
{
    // Registers mappings for authentication data types.
    public void Register(TypeAdapterConfig config)
    {
        // Maps properties from the RegisterRequest DTO to the RegisterCommand.
        // Facilitates handling of user registration data.
        config.NewConfig<RegisterRequest, RegisterCommand>();

        // Maps properties from the LoginRequest DTO to the LoginQuery.
        // Used for processing user login requests.
        config.NewConfig<LoginRequest, LoginQuery>();

        // Maps AuthenticationResult to AuthenticationResponse.
        // Directly transfers user details to the response object.
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}
