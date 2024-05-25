namespace BuberDinner.Contracts.Menus;

// Represents the response containing details of a menu, used by the API to send menu data to the client.
public record MenuResponse(
    string Id,                           // The unique identifier of the menu.
    string Name,                         // The name of the menu.
    string Description,                  // The description of the menu.
    float? AverageRating,                // The average rating of the menu, if available.
    List<MenuSectionResponse> Sections,  // The sections of the menu, each containing multiple items.
    string HostId,                       // The unique identifier of the host who created the menu.
    List<string> DinnerIds,              // The list of dinner IDs associated with the menu.
    List<string> MenuReviewIds,          // The list of menu review IDs associated with the menu.
    DateTime CreatedDateTime,            // The date and time when the menu was created.
    DateTime UpdatedDateTime);           // The date and time when the menu was last updated.

// Represents a section within a menu in the MenuResponse, used to structure the menu sections.
public record MenuSectionResponse(
    string Id,                          // The unique identifier of the menu section.
    string Name,                        // The name of the menu section.
    string Description,                 // The description of the menu section.
    List<MenuItemResponse> Items);      // The items within the menu section.

// Represents an item within a menu section in the MenuSectionResponse, used to list items.
public record MenuItemResponse(
    string Id,                         // The unique identifier of the menu item.
    string Name,                       // The name of the menu item.
    string Description);               // The description of the menu item.