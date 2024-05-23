namespace BuberDinner.Domain.Common.Models;

// Abstract base class for creating value objects in the domain.
// Value objects are treated as equal if all their component values are equal.
public abstract class ValueObject : IEquatable<ValueObject>
{
    // Abstract method to be implemented by derived classes specifying the values that contribute to object equality.
    // This method should return all components of the object that should be used for equality comparison.
    public abstract IEnumerable<object> GetEqualityComponents();

    // Overrides the equality check to compare value objects based on their equality components rather than references.
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;  // Ensures nulls are handled and only objects of the same type are compared.
        }

        var valueObject = (ValueObject)obj;

        // Ensures structural equality by verifying that both value objects have identical components in the same order.
        return GetEqualityComponents()
            .SequenceEqual(valueObject.GetEqualityComponents());
    }

    // Overloads the == operator to use Equals method for value comparison instead of reference comparison.
    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return Equals(left, right);
    }

    // Overloads the != operator to use Equals method for value comparison.
    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !Equals(left, right);
    }

    // Computes a hash code by combining the hashes of key attributes using XOR.
    // This is crucial for efficient data retrieval in hash tables, which store and manage data using hash codes for fast access.
    public override int GetHashCode()
    {
        // Combines the hash code of each component using XOR to reduce the likelihood of collision.
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    // Implements IEquatable for stronger type checking in Equals method.
    public bool Equals(ValueObject? other)
    {
        return Equals((object?)other);
    }
}