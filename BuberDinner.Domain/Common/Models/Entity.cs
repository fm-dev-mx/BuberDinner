namespace BuberDinner.Domain.Common.Models;

// Abstract base class for domain entities. All entities are defined by an identity.
// This generic class provides common functionality for entity objects using a generic identifier (Id) of type TId.
public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    // The identifier for the entity, generic to allow various types (e.g., int, Guid).
    public TId Id { get; protected set; }

    // Constructor to set the entity's ID upon creation.
    protected Entity(TId id) => Id = id;

    // Overrides the equality check to compare entities based on their IDs rather than references.
    public override bool Equals(object? obj)
    {
        // Check if the passed object is of the same entity type and compare IDs for equality.
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    // Implements IEquatable for type-safe comparison of entities, relying on the overridden Equals method.
    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    // Overloads the == operator to use the Equals method for equality comparison, ensuring that entities are compared by ID.
    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    // Overloads the != operator to negate the result of the == operator, providing a consistent inequality check.
    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !Equals(left, right);
    }

    // Overrides GetHashCode to provide a hash code based on the entity's ID.
    // This is crucial for using entities as keys in collections that rely on hash codes.
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}