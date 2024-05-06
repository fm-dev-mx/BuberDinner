using System.Reflection;
using BuberDinner.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

// Sets up dependency injection for the application services.
public static class DependencyInjection
{
    // Adds essential services to the IServiceCollection, configuring components necessary for the application's operation.
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Sets up MediatR to support the CQRS pattern by automatically discovering and registering its components,
        // such as handlers, pre-processors, and pipeline behaviors.
        // (e.g. LoginQueryHandler, RegisterCommandHandler, ValidationBehavior, etc.)
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        // Adds ValidationBehavior to the MediatR pipeline to validate requests at runtime before processing.
        // This behavior is registered with a scoped lifecycle to ensure request validation occurs within the context of each web request.
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        /// Scans the current assembly for FluentValidation validators and adds them to the service collection.
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Returns the services to continue configuration.
        return services;
    }
}