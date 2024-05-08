using System.Text;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Persistence;
using BuberDinner.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure;

// Static class that extends IServiceCollection to include services specific to the Infrastructure layer.
public static class DependencyInjection
{
    // Adds infrastructure-specific services and configurations to the DI container.
    // ConfigurationManager is used to pass configuration settings into services.
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        // Adds JWT Bearer authentication to the request pipeline.
        // Reads configuration settings for the JWT token from the appsettings.json file.
        services.AddAuth(configuration);

        // Registers the DateTimeProvider as a singleton to ensure a consistent date-time source across the application.
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        // Registers the UserRepository as a scoped service to handle user data management.
        // Scoped lifetime ensures that a new instance is created for each request, suitable for handling user data context.
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        // Registers the JwtSettings as a singleton to ensure a single instance handles all JWT settings throughout the application's lifetime.
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        // Configure JwtSettings from the app settings and bind it to the JwtSettings class.
        // This enables the JwtTokenGenerator to retrieve its settings from the IConfiguration instance.
        services.AddSingleton(Options.Create(jwtSettings));

        // Registers the JwtTokenGenerator as a singleton to ensure a single instance handles all JWT creation throughout the application's lifetime.
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        // Adds JWT Bearer authentication to the request pipeline.
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
                // Validates the issuer, audience, lifetime, and signing key of the incoming token.
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    // Specifies the expected issuer of the incoming token.
                    ValidIssuer = jwtSettings.Issuer,

                    // Specifies the expected audience of the incoming token.
                    ValidAudience = jwtSettings.Audience,

                    // Defines the encryption key that must be used to validate the token.
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                }
            );

        return services;
    }
}