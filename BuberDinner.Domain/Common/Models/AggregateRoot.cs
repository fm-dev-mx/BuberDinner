namespace BuberDinner.Domain.Common.Models;

// Abstract base class for aggregate roots in the domain model.
// Aggregate roots serve as the entry point for any operations on an aggregate,
// ensuring consistency and enforcing business rules across the aggregate's entire graph.
public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{
    // Constructor initializes the AggregateRoot with an ID, leveraging the base Entity class constructor.
    // This design enforces that every aggregate root must have an identifier, supporting the principle that
    // each aggregate must be uniquely identifiable and accessible through its root.
    protected AggregateRoot(TId id) : base(id)
    {
    }
}