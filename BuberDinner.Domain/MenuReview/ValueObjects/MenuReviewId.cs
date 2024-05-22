using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.MenuReview.ValueObjects;

// Represents a unique identifier for a menu review.
// This value object ensures that each menu review can be uniquely identified and provides value-based equality.
public sealed class MenuReviewId : ValueObject
{
    // The actual string value representing the menu review ID.
    public string Value { get; }

    // Private constructor to enforce the use of the factory methods for instantiation.
    // This constructor generates a menu review ID based on the provided menu, dinner, and guest IDs.
    private MenuReviewId(MenuId menuId, DinnerId dinnerId, GuestId guestId)
        => Value = $"MenuReview_{menuId.Value}_{dinnerId.Value}_{guestId.Value}";

    // Private constructor to enforce the use of the factory methods for instantiation.
    // This constructor directly accepts a pre-generated menu review ID value.
    private MenuReviewId(string value) => Value = value;

    // Factory method to create a new MenuReviewId from menu, dinner, and guest IDs.
    // This method generates a menu review ID by combining the menu, dinner, and guest IDs.
    public static MenuReviewId Create(MenuId menuId, DinnerId dinnerId, GuestId guestId)
        => new(menuId, dinnerId, guestId);

    // Factory method to create a new MenuReviewId from a pre-generated value.
    // This method allows creating a MenuReviewId with an existing ID value.
    public static MenuReviewId Create(string value) => new(value);

    // Overrides the GetEqualityComponents method to define the components that are used for equality comparison.
    // In this case, the Value property is the sole component that determines equality.
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}