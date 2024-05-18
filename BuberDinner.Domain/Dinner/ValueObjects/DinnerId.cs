using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects
{
    // Sealed class representing a unique identifier for a Dinner entity.
    public sealed class DinnerId : ValueObject
    {
        // Property to hold the GUID value.
        public Guid Value { get; }

        // Private constructor to initialize the DinnerId with a GUID value.
        private DinnerId(Guid value) => Value = value;

        // Factory method to create a new unique DinnerId.
        public static DinnerId CreateUnique() => new(Guid.NewGuid());

        // Factory method to create a DinnerId from an existing GUID value.
        public static DinnerId Create(Guid value) => new(value);

        // Override to provide the components that make up the equality check.
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
