using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.User;

// Represents a user in the Buber Dinner application.
// This aggregate root includes details about the user's profile and credentials.
public sealed class User : AggregateRoot<UserId>
{
    // Personal details of the user.
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    // The user's password. Note: Password hashing should be implemented for security.
    public string Password { get; }
    // Timestamps for tracking creation and updates.
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    // Private constructor to initialize the User with the provided details.
    // This constructor is private to enforce the use of the Create factory method for instantiation.
    private User(
        string firstName,
        string lastName,
        string email,
        string password,
        UserId? userId = null)
        : base(userId ?? UserId.CreateUnique())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
    }

    // Factory method to create a new User.
    // This method initializes a User with the provided personal details and generates timestamps for creation and last update.
    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        //  TODO: enforce invariants such as non-null values.
        return new User(
            firstName,
            lastName,
            email,
            password);
    }
}