using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host;

// Represents a host in the Buber Dinner application.
// This aggregate root includes comprehensive details about the host, their profile, and the dinners they host.
public sealed class Host : AggregateRoot<HostId>
{
    // Lists to track IDs of menus and dinners associated with the host.
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();

    // Personal details of the host.
    public string FirstName { get; }
    public string LastName { get; }
    public Uri ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public UserId UserId { get; }

    // Read-only access to the lists of IDs for menus and dinners.
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

    // Timestamps for tracking creation and updates.
    public DateTime CreatedDateTime { get; } = DateTime.UtcNow;
    public DateTime UpdatedDateTime { get; } = DateTime.UtcNow;

    // Private constructor to initialize the Host with the provided details.
    // This constructor is private to enforce the use of the Create factory method for instantiation.
    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        Uri profileImage,
        UserId userId,
        AverageRating averageRating)
        : base(hostId ?? HostId.Create(userId))
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
        AverageRating = averageRating;
    }

    // Factory method to create a new Host.
    // This method initializes a Host with the provided personal details and generates timestamps for creation and last update.
    public static Host Create(
        string firstName,
        string lastName,
        Uri profileImage,
        UserId userId)
    {
        // TODO: enforce invariants such as non-null values and valid URI.
        return new(
            HostId.Create(userId),
            firstName,
            lastName,
            profileImage,
            userId,
            AverageRating.CreateNew());
    }
}