using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Infrastructure.Persistence;

// Implements IUserRepository providing a concrete implementation for user persistence methods.
// This class is responsible for managing user data within the application's memory.
public class UserRepository : IUserRepository
{
    // A static list used to simulate a database table storing users.
    // In a production environment, this would be replaced with a database access mechanism.
    private static readonly List<User> _users = new();

    // Adds a new user to the repository.
    // This method simulates inserting a user record into a database.
    public void Add(User user)
    {
        _users.Add(user); // Adds the user to the static list.
    }

    // Retrieves a user by their email address.
    // This method simulates a database query to find a user by their unique email identifier.
    public User? GetUserByEmail(string email)
    {
        // Returns the first user that matches the given email or null if no match is found.
        // SingleOrDefault is used to ensure that only one user with the specified email exists.
        return _users.SingleOrDefault(x => x.Email == email);
    }
}