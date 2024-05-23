using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Entities;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.DomainAggregate.Dinner;

// Represents a dinner aggregate root in the domain.
// An aggregate root is an entity that is the entry point for the aggregate, ensuring consistency and enforcing business rules.
public sealed class Dinner : AggregateRoot<DinnerId>
{
    // A list of reservations for the dinner. Managed internally and exposed as read-only.
    private readonly List<Reservation> _reservations = new();

    // The name of the dinner event.
    public string Name { get; }

    // A description of the dinner event.
    public string Description { get; }

    // The date and time when the dinner starts.
    public DateTime StartDateTime { get; }

    // The date and time when the dinner ends.
    public DateTime EndDateTime { get; }

    // The actual start time of the dinner, which may be null if the dinner hasn't started yet.
    public DateTime? StartedDateTime { get; }

    // The actual end time of the dinner, which may be null if the dinner hasn't ended yet.
    public DateTime? EndedDateTime { get; }

    // The status of the dinner event (e.g., upcoming, ongoing, completed).
    public DinnerStatus Status { get; }

    // Indicates whether the dinner is open to the public.
    public bool IsPublic { get; }

    // The maximum number of guests allowed for the dinner.
    public int MaxGuests { get; }

    // The price per guest for attending the dinner.
    public Price Price { get; }

    // The ID of the host who is organizing the dinner.
    public HostId HostId { get; }

    // The ID of the menu associated with the dinner.
    public MenuId MenuId { get; }

    // The URL of an image representing the dinner.
    public Uri ImageUrl { get; }

    // The location where the dinner will take place.
    public Location Location { get; }

    // Provides read-only access to the list of reservations.
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    // The date and time when the dinner was created.
    public DateTime CreatedDateTime { get; }

    // The date and time when the dinner was last updated.
    public DateTime UpdatedDateTime { get; }

    // Private constructor to enforce the use of the Create factory method.
    private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        Uri imageUrl,
        Location location)
        : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        MenuId = menuId;
        HostId = hostId;
        ImageUrl = imageUrl;
        Location = location;
        Status = DinnerStatus.Upcoming;
        CreatedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
    }

    // Factory method to initialize a Dinner with a unique ID and the provided details.
    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        MenuId menuId,
        HostId hostId,
        Uri imageUrl,
        Location location)
    {
        // TODO: enforce invariants such as name not being null or empty, description length, valid dates, etc.
        return new Dinner(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            imageUrl,
            location);
    }
}