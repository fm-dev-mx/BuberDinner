using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Persistence;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure;

// Static class that extends IServiceCollection to include services specific to the Infrastructure layer.
public static class DependencyInjection
{
    // Adds infrastructure-specific services and configurations to the DI container.
    // ConfigurationManager is used to pass configuration settings into services.
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        // Configure JwtSettings from the app settings and bind it to the JwtSettings class.
        // This enables the JwtTokenGenerator to retrieve its settings from the IConfiguration instance.
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        // Registers the JwtTokenGenerator as a singleton to ensure a single instance handles all JWT creation throughout the application's lifetime.
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        // Registers the DateTimeProvider as a singleton to ensure a consistent date-time source across the application.
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        // Registers the UserRepository as a scoped service to handle user data management.
        // Scoped lifetime ensures that a new instance is created for each request, suitable for handling user data context.
        services.AddScoped<IUserRepository, UserRepository>();

        // Returns the modified IServiceCollection to enable fluent configuration.
        return services;
    }
}