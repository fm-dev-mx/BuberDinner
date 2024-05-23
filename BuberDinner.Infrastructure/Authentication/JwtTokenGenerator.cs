using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Domain.UserAggregate;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure.Authentication;

// This class implements the IJwtTokenGenerator interface to manage the creation of JSON Web Tokens (JWTs),
// which are essential for secure and stateless authentication across the web application.
public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings; // Stores the JWT configuration settings from the application's configuration files.
    private readonly IDateTimeProvider _dateTimeProvider; // Provides the current UTC date and time to set accurate token expiration.

    // Constructor initializes the token generator with configuration settings and a time provider.
    // The IOptions pattern is employed to abstract the configuration complexities, simplifying the management of JWT settings.
    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider; // Ensures that token expiry is accurately calculated using the current time.
        _jwtSettings = jwtOptions.Value; // Extracts JWT settings directly from the provided configuration options.
    }

    // Generates a JWT for a user by encapsulating user-specific claims and securing the token with a cryptographic key.
    public string GenerateToken(User user)
    {
        // The SymmetricSecurityKey is created from the secret key specified in settings, which must be kept confidential
        // to maintain the integrity and security of the generated tokens.
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));

        // HMAC SHA256 is selected for signing due to its robust security and performance efficiency.
        var signingCredentials = new SigningCredentials(
            securityKey, SecurityAlgorithms.HmacSha256);

        // Set up claims for the JWT, including standard claims like subject, name, and a unique JWT ID for tracking.
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()!),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        // Constructs the JWT with specified claims, issuer, audience, and a set expiration time,
        // It serves as the blueprint from which the actual token string will be generated.
        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        // The token is serialized to a string format, making it suitable for transmission over HTTP headers.
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}