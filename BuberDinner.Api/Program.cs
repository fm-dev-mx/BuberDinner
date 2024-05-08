using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

// Create a new builder for the web application.
var builder = WebApplication.CreateBuilder(args);
{
    // AddPresentation - Adds MVC controllers and other presentation layer services.
    // AddApplication - Adds services and configurations specific to the application layer.
    // AddInfrastructure - Adds services like database context, repositories, etc., configured from app settings.
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

// Build the web application from the configured services.
var app = builder.Build();
{
    // Configure middleware to handle exceptions globally and map them to a dedicated error handling route.
    app.UseExceptionHandler("/error");

    // Enforce HTTPS to improve security by redirecting HTTP requests to HTTPS.
    app.UseHttpsRedirection();

    // Adds authentication middleware to the application pipeline, enabling authentication for incoming requests.
    app.UseAuthentication();

    // Integrates the authorization middleware to enforce security policies on endpoints, ensuring only authorized access based on predefined rules.
    app.UseAuthorization();

    // Map controller routes to make them available as HTTP endpoints.
    app.MapControllers();

    // Start the application and begin listening for incoming requests.
    app.Run();
}