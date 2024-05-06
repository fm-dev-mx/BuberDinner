namespace BuberDinner.Domain.Entities;

// Defines a User entity which is a core component of the domain model in the BuberDinner application.
// This class encapsulates all the necessary user-related data that is persisted in the database.
public class User
{
    // Unique identifier for the user
    public Guid Id { get; set; } = Guid.NewGuid();

    // First name of the user
    public string FirstName { get; set; } = null!;

    // Last name of the user
    public string LastName { get; set; } = null!;

    // Email address of the user
    // serves as a unique identifier for login and communication purposes
    public string Email { get; set; } = null!;

    // Password for the user's account
    // Stored securely and used for authentication
    // Note: This should be stored in a hashed format to ensure security
    public string Password { get; set; } = null!;
}