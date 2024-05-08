using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

// Defines the route prefix for all actions within this controller.
[Route("[controller]")]
public class DinnersController : ApiController
{
    // HTTP GET method to list all dinners. Accessible at GET /dinners.
    // This action returns an empty array, symbolizing the retrieval of dinners,
    // which would typically involve fetching data from a database or external service.
    [HttpGet]
    public IActionResult ListDinners()
    {
        // Returns an OK (200) HTTP status code along with an empty string array.
        // The array is a placeholder, indicating where dinner data would be returned.
        return Ok(Array.Empty<string>());
    }
}