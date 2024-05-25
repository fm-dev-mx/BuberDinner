using System.Text;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Domain.MenuAggregate;
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
        // Configures authentication and persistence services.
        services
            .AddAuth(configuration)
            .AddPersistence();

        // Registers the DateTimeProvider as a singleton to ensure a consistent date-time source across the application.
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    // Registers persistence services to the DI container.
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        // Registers the UserRepository as a scoped service to handle user data management.
        // Scoped lifetime ensures a new instance for each request.
        services.AddScoped<IUserRepository, UserRepository>();

        // Registers the MenuRepository as a scoped service to handle menu data management.
        // Scoped lifetime ensures a new instance for each request.
        services.AddScoped<IMenuRepository, MenuRepository>();

        return services;
    }

    // Configures authentication services and JWT settings.
    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        // Binds JWT settings from the configuration to the JwtSettings class.
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));

        // Registers the JwtTokenGenerator as a singleton to ensure a single instance handles all JWT creation.
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        // Adds JWT Bearer authentication to the request pipeline.
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>

                // Configures token validation parameters.
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
                        Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                });

        return services;
    }
}