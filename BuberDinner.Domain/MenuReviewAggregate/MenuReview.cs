using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuReviewAggregate;

// Represents a menu review in the Buber Dinner application.
// This aggregate root includes details about the review rating, comment, and references to the related host, menu, guest, and dinner.
public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    // The rating given to the menu.
    public Rating Rating { get; }

    // The comment provided by the guest about the menu.
    public string Comment { get; }

    // The ID of the host associated with this menu review.
    public HostId HostId { get; }

    // The ID of the menu being reviewed.
    public MenuId MenuId { get; }

    // The ID of the guest who provided the review.
    public GuestId GuestId { get; }

    // The ID of the dinner event associated with this menu review.
    public DinnerId DinnerId { get; }

    // Private constructor to initialize the MenuReview with the provided details.
    // This constructor is private to enforce the use of the Create factory method for instantiation.
    private MenuReview(
        MenuReviewId menuReviewId,
        Rating rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId) : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
    }

    // Factory method to create a new MenuReview.
    // This method initializes a MenuReview with the provided rating, comment, and references to the related host, menu, guest, and dinner.
    public static MenuReview Create(
        int rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        MenuReviewId? menuReviewId = null)
    {
        var ratingValueObject = Rating.Create(rating);

        return new MenuReview(
            menuReviewId ?? MenuReviewId.Create(menuId, dinnerId, guestId),
            ratingValueObject,
            comment,
            hostId,
            menuId,
            guestId,
            dinnerId);
    }
}