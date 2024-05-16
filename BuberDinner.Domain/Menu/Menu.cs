using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu;

// Represents a menu aggregate root in the domain.
// An aggregate root is an entity that is the entry point for the aggregate, ensuring consistency and enforcing business rules.
public sealed class Menu : AggregateRoot<MenuId>
{
    // A list of sections in the menu. Managed internally and exposed as read-only.
    private readonly List<MenuSection> _sections = new();

    // A list of associated dinner IDs. Managed internally and exposed as read-only.
    private readonly List<DinnerId> _dinnerIds = new();

    // A list of associated menu review IDs. Managed internally and exposed as read-only.
    private readonly List<MenuReviewId> _menuReviewIds = new();

    // The name of the menu.
    public string Name { get; }

    // The description of the menu.
    public string Description { get; }

    // The average rating of the menu.
    public AverageRating AverageRating { get; }

    // Provides read-only access to the list of menu sections.
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    // The ID of the host who created the menu.
    public HostId HostId { get; }

    // Provides read-only access to the list of associated dinner IDs.
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    // Provides read-only access to the list of associated menu review IDs.
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    // The date and time when the menu was created.
    public DateTime CreatedDateTime { get; }

    // The date and time when the menu was last updated.
    public DateTime UpdatedDateTime { get; }

    // Private constructor to initialize the Menu with specific details.
    // This constructor is private to enforce the use of the Create factory method.
    private Menu(
        MenuId menuId,
        HostId hostId,
        string name,
        string description,
        AverageRating averageRating,
        List<MenuSection> sections)
        : base(menuId)
    {
        HostId = hostId;
        Name = name;
        Description = description;
        AverageRating = averageRating;
        _sections = sections;
        CreatedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
    }

    // Factory method to create a new Menu.
    // This method initializes a Menu with a unique ID, given host ID, name, description, and optionally, sections.
    public static Menu Create(
        HostId hostId,
        string name,
        string description,
        List<MenuSection>? sections = null)
    {
        // TODO: enforce invariants such as name not being null or empty, description length, etc.
        return new Menu(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            AverageRating.CreateNew(),
            sections ?? new List<MenuSection>());
    }
}