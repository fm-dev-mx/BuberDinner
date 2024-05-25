using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

// Controller for handling menu-related operations under a specific host
[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    // Private field for the mapper instance, used for mapping between request and command objects
    private readonly IMapper _mapper;

    private readonly ISender _mediator;

    // Constructor to initialize the IMapper instance via dependency injection
    public MenusController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    // HTTP POST endpoint for creating a new menu
    [HttpPost]
    public async Task<IActionResult> CreateMenu(
        CreateMenuRequest request, // The request object containing the details of the menu to be created
        string hostId) // The hostId parameter from the route, representing the ID of the host creating the menu
    {
        // Map the request and hostId to a CreateMenuCommand object using the mapper
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));

        var createMenuResult = await _mediator.Send(command);

        // For now, return the request object as a placeholder response
        return createMenuResult.Match(
            menu => Ok(_mapper.Map<MenuResponse>(menu)),
            errors => Problem(errors));
    }
}