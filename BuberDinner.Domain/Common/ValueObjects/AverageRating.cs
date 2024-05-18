using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

// Represents an average rating value object with a value and a count of ratings.
// Designed as a value object to ensure value-based equality.
public sealed class AverageRating : ValueObject
{
    // The average rating value.
    public double Value { get; private set; }
    // The number of ratings contributing to the average.
    public int NumRatings { get; private set; }

    // Private constructor to enforce the use of the CreateNew factory method for instantiation.
    private AverageRating(double value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }

    // Factory method to create a new AverageRating.
    // This method initializes an AverageRating with an optional initial rating and number of ratings.
    public static AverageRating CreateNew(double rating = 0, int numRatings = 0)
    {
        return new(rating, numRatings);
    }

    // Method to add a new rating to the average.
    // This method updates the average value and increments the number of ratings.
    public void AddRating(Rating rating)
    {
        // Updates the average rating with the new rating value.
        Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
    }

    // Internal method to remove a rating from the average.
    // This method updates the average value and decrements the number of ratings.
    internal void RemoveRating(Rating rating)
    {
        // Updates the average rating by removing the rating value.
        Value = ((Value * NumRatings) - rating.Value) / --NumRatings;
    }

    // Overrides the GetEqualityComponents method to define the components that are used for equality comparison.
    // This method ensures that AverageRatings are considered equal if their values match.
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}