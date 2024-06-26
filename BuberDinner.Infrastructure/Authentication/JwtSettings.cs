namespace BuberDinner.Infrastructure.Authentication;

// Configuration class for JWT (JSON Web Token) settings used in authentication.
// This class maps JWT-related settings from the application's configuration files, such as appsettings.json,
public class JwtSettings
{
    // The name of the configuration section in appsettings.json where JWT settings are specified.
    public const string SectionName = "JwtSettings";

    // Secret key used for signing JWTs. This key must be stored securely and not exposed in the application code.
    // It is recommended to use User Secrets during development to prevent unauthorized access to this key.
    public string Secret { get; init; } = null!;

    // The expiration time in minutes for JWTs. This determines the session duration.
    public int ExpiryMinutes { get; init; }

    // Specifies the issuer of the JWTs. This is typically the name of your application or organization.
    // Validating the issuer ensures that the JWTs are generated by a trusted source, securing the authentication process.
    public string Issuer { get; init; } = null!;

    // Specifies the intended audience for the JWTs, such as a specific application or user group.
    // This property helps ensure that the token is not misused by services it was not intended for.
    public string Audience { get; init; } = null!;
}