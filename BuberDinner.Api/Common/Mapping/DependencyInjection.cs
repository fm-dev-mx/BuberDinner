using System.Reflection;
using Mapster;
using MapsterMapper;

namespace BuberDinner.Api.Common.Mapping;

// Extension method class for IServiceCollection to set up mapping services.
public static class DependencyInjection
{
    // Configures and adds mapping tools to the service collection.
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        // Set up global configuration for Mapster, a library for mapping objects.
        var config = TypeAdapterConfig.GlobalSettings;
        // Automatically finds and registers all Mapster mappings in this assembly.
        config.Scan(Assembly.GetExecutingAssembly());

        // Add the configuration to the services as a single instance shared across the app.
        services.AddSingleton(config);
        // Add a mapper service that can be used to map objects in the app.
        services.AddScoped<IMapper, ServiceMapper>();

        // Return the updated services collection.
        return services;
    }
}