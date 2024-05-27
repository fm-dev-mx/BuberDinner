using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

// Handles the creation of a new menu. This class is responsible for processing the CreateMenuCommand
// by creating a new Menu entity and persisting it using the IMenuRepository.
public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    // Constructor to inject the menu repository dependency.
    // The IMenuRepository is used to interact with the data storage for Menu entities.
    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    // Handles the CreateMenuCommand to create and persist a new menu.
    // This method is called by the MediatR pipeline when a CreateMenuCommand is sent.
    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Create a new Menu entity using the details provided in the command.
        // The HostId, Name, Description, and Sections are mapped from the request to the new Menu entity.
        var menu = Menu.Create(
            hostId: HostId.Create(request.HostId),
            name: request.Name,
            description: request.Description,
            sections: request.Sections.ConvertAll(section => MenuSection.Create(
                section.Name,
                section.Description,
                section.Items.ConvertAll(item => MenuItem.Create(
                    item.Name,
                    item.Description)))));

        // Persist the newly created menu using the repository.
        // The Add method of the IMenuRepository is called to save the menu to the data storage.
        _menuRepository.Add(menu);

        // Return the created menu wrapped in an ErrorOr type.
        // This allows for handling both successful creation and potential errors in a uniform manner.
        return menu;
    }
}