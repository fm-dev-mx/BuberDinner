using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

// Represents a price associated with a dinner event.
// This value object ensures immutability and value-based equality.
public sealed class Price : ValueObject
{
    // The monetary amount of the price.
    public decimal Amount { get; }

    // The currency of the price (e.g., USD, EUR).
    public string Currency { get; }

    // Private constructor to enforce the use of the Create factory method.
    private Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    // Factory method to create a new Price.
    public static Price Create(decimal amount, string currency)
    {
        // TODO: Enforce invariants such as valid amount (e.g., non-negative) and valid currency codes.
        return new Price(amount, currency);
    }

    // Overrides the GetEqualityComponents method to define the components that are used for equality comparison.
    // In this case, the Amount and Currency properties are used to determine equality.
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
