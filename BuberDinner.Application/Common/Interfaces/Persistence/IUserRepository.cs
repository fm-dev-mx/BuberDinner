using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interfaces.Persistence;

// Interface defining the contract for user repository operations.
// IUserRepository outlines methods for managing user data, enabling abstraction from the actual data access implementation.
public interface IUserRepository
{
    // Defines a method contract to retrieve a user by their email.
    // Returns a User entity if the user exists in the persistence storage, otherwise null.
    // This method is essential for operations that require user verification, such as authentication and duplication checks during registration.
    User? GetUserByEmail(string email);

    // Defines a method contract to add a new user to the persistence storage.
    // This method is used for creating new user entries, facilitating user registration processes.
    void Add(User user);
}
