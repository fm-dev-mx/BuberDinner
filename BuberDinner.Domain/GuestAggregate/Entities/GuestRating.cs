using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using ErrorOr;

namespace BuberDinner.Domain.GuestAggregate.Entities;

// Represents a guest rating for a dinner event.
// Each GuestRating is uniquely identified by a GuestRatingId and encapsulates details about the guest, dinner, and rating.
public sealed class GuestRating : Entity<GuestRatingId>
{
    // The ID of the host who provided the rating.
    public HostId HostId { get; }

    // The ID of the dinner event being rated.
    public DinnerId DinnerId { get; }

    // The rating provided by the guest.
    public Rating Rating { get; }

    // The date and time when the rating was created.
    public DateTime CreatedDateTime { get; }

    // The date and time when the rating was last updated.
    public DateTime UpdatedDateTime { get; }

    // Private constructor to enforce the use of the Create factory method.
    private GuestRating(DinnerId dinnerId, HostId hostId, Rating rating)
        : base(GuestRatingId.Create(dinnerId, hostId)) // Generate GuestRatingId from dinnerId and hostId
    {
        DinnerId = dinnerId;
        HostId = hostId;
        Rating = rating;
        CreatedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
    }

    // Factory method to create a new GuestRating.
    public static ErrorOr<GuestRating> Create(DinnerId dinnerId, HostId hostId, int rating)
    {
        // Create the rating value object from the provided rating.
        var ratingValueObject = Rating.Create(rating);

        // Return the new GuestRating.
        return new GuestRating(dinnerId, hostId, ratingValueObject);
    }
}