using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.MenuAggregate;

using Mapster;

using MenuItem = BuberDinner.Domain.MenuAggregate.Entities.MenuItem;
using MenuSection = BuberDinner.Domain.MenuAggregate.Entities.MenuSection;

namespace BuberDinner.Api.Common.Mapping;

// Configuration class for mapping configurations using Mapster.
// This class defines how different objects in the application map to each other.
public class MenuMappingConfig : IRegister
{
    // Method to register mapping configurations.
    public void Register(TypeAdapterConfig config)
    {
        // Mapping configuration from a tuple of CreateMenuRequest and HostId to CreateMenuCommand.
        // This is used in the command handler to create a new menu based on the request data and host ID.
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId) // Map HostId
            .Map(dest => dest, src => src.Request); // Map the rest of the request properties

        // Mapping configuration from Menu domain entity to MenuResponse.
        // This is used to transform the Menu entity into a response object that is sent back to the client.
        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value) // Map Menu Id
            .Map(dest => dest.AverageRating, src => src.AverageRating.NumRatings > 0 ? src.AverageRating.Value : 0) // Map AverageRating
            .Map(dest => dest.HostId, src => src.HostId.Value) // Map HostId
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(x => x.Value)) // Map DinnerIds
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(x => x.Value)); // Map MenuReviewIds

        // Mapping configuration from MenuSection domain entity to MenuSectionResponse.
        // This is used to transform the MenuSection entity into a response object that is part of the menu details sent back to the client.
        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value); // Map MenuSection Id

        // Mapping configuration from MenuItem domain entity to MenuItemResponse.
        // This is used to transform the MenuItem entity into a response object that is part of the menu section details sent back to the client.
        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value); // Map MenuItem Id
    }
}