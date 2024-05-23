using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

// Represents a unique identifier for a menu section.
// This value object ensures that each menu section can be uniquely identified and provides value-based equality.
public sealed class MenuSectionId : ValueObject
{
    // The actual string value representing the menu section ID.
    // The ID is formatted as "Section_{sectionName}" to ensure uniqueness and consistency.
    public string Value { get; }

    // Private constructor to enforce the use of the factory method for instantiation.
    private MenuSectionId(string sectionName)
    {
        Value = $"Section_{sectionName}";
    }

    // Factory method to create a new MenuSectionId.
    // This method ensures that each MenuSectionId is generated with a consistent format.
    public static MenuSectionId Create(string sectionName)
    {
         // TODO: Add validation logic if necessary to ensure sectionName is valid.
        return new MenuSectionId(sectionName);
    }

    // Overrides the GetEqualityComponents method to define the components that are used for equality comparison.
    // In this case, the Value property is the sole component that determines equality.
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}