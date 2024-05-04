using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

// Controller responsible for handling global errors across the application.
public class ErrorsController : ControllerBase
{
    // Defines a route that is called when an unhandled exception occurs.
    [Route("/error")]
    public IActionResult Error()
    {
        // Retrieve the exception details from the current HTTP context.
        // IExceptionHandlerFeature captures synchronous and asynchronous exceptions from the HTTP pipeline.
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        // Generate a Problem Details response. Automatically includes details like status code and problem description.
        // This response is compliant with the RFC 7807 about Problem Details for HTTP APIs.
        return Problem();
    }
}