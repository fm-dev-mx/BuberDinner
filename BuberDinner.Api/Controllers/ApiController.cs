using BuberDinner.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberDinner.Api.Controllers;

// Base controller class that provides common functionalities for error handling across all controllers in the application.
[ApiController]
[Authorize] // Ensures that all actions within the derived controllers require authorization.
public class ApiController : ControllerBase
{
    // Handles a list of errors by determining the appropriate response based on error type.
    protected IActionResult Problem(List<Error> errors)
    {
        // If there are no errors, return a generic server error.
        if (errors.Count is 0)
        {
            return Problem();
        }

        // If all errors are validation types, return a validation problem response.
        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);
        }

        // Store errors in HttpContext for further processing or logging.
        HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        // Handle the first error using a more specific problem method.
        return Problem(errors[0]);
    }

    // Generates a ProblemDetails response based on a single error's type and description.
    private IActionResult Problem(Error error)
    {
        // Map the error type to the corresponding HTTP status code.
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        };

        // Return a problem detail response with the appropriate status code and error description.
        return Problem(statusCode: statusCode, title: error.Description);
    }

    // Constructs a ValidationProblemDetails response using a list of errors, adding each to the ModelState.
    private IActionResult ValidationProblem(List<Error> errors)
    {
        // Initialize a ModelStateDictionary to store the errors.
        var modelStateDictionary = new ModelStateDictionary();

        // Add each error from the list to the ModelState with its code and description.
        foreach (var error in errors)
        {
            modelStateDictionary.AddModelError(error.Code, error.Description);
        }

        // Return a validation problem response using the filled ModelState.
        return ValidationProblem(modelStateDictionary);
    }
}