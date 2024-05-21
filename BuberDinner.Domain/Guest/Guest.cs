using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.Entities;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest;

// Represents a guest in the Buber Dinner application, uniquely identified by a GuestId
// This aggregate root includes comprehensive details about the guest, their dinners, bills, menu reviews, and ratings.
public sealed class Guest : AggregateRoot<GuestId>
{
     // Lists to track IDs of dinners and bills associated with the guest.
    private readonly List<DinnerId> _upcomingDinnersIds = new();
    private readonly List<DinnerId> _pastDinnersIds = new();
    private readonly List<DinnerId> _pendingDinnersIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<GuestRating> _ratings = new();

    // Personal details of the guest.
    public string FirstName { get; }
    public string LastName { get; }
    public Uri ProfileImage{ get; }
    public UserId UserId{ get; }

    // Read-only access to the lists of IDs for dinners, bills, and menu reviews.
    public IReadOnlyList<DinnerId> UpcomingDinnersIds => _upcomingDinnersIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnersIds => _pastDinnersIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnersIds => _pendingDinnersIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public IReadOnlyList<GuestRating> Ratings => _ratings.AsReadOnly();

    // Timestamps for tracking creation and updates.
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    // Private constructor to initialize the Guest with required details and optional parameters.
    // This constructor is private to enforce the use of the Create factory method for instantiation.
    private Guest(
        string firstName,
        string lastName,
        Uri profileImage,
        UserId userId,
        GuestRating? guestRating = null,
        GuestId? guestId = null)
        : base(guestId ?? GuestId.Create(userId))
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        UserId = userId;
    }

    // Factory method to create a new Guest.
    // This method initializes a Guest with the provided personal details and generates timestamps for creation and last update.
    public static Guest Create(
        string firstName,
        string lastName,
        Uri profileImage,
        UserId userId)
    {
        // TODO: enforce invariants such as non-null values and valid URI.
        return new Guest(
            firstName,
            lastName,
            profileImage,
            userId);
    }
}