using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api;

// Provides an extension method for IServiceCollection to configure presentation-related services.
public static class DependencyInjection
{
    // Adds presentation-specific services to the ASP.NET Core dependency injection container.
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        // Register controller services to handle web API requests.
        services.AddControllers();

        // Registers BuberDinnerProblemDetailsFactory as the custom ProblemDetailsFactory to manage the creation of detailed error responses.
        services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();

        // Register object mapping services to facilitate conversion between different object types within the application.
        services.AddMappings();

        return services;
    }
}