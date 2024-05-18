using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

// Represents a location associated with a dinner event.
// This value object ensures immutability and value-based equality.
public class Location : ValueObject
{
    // The name of the location (e.g., restaurant name, venue name)
    public string Name { get; }

    // The address of the location.
    public string Address { get; }

    // The latitude coordinate of the location.
    public double Latitude { get; }

    // The longitude coordinate of the location.
    public double Longitude { get; }

    // Private constructor to enforce the use of the Create factory method.
    private Location(string name, string address, double latitude, double longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    // Factory method to create a new Location instance.
    // This method initializes a Location with the provided details.
    public static Location Create(string name, string address, double latitude, double longitude)
    {
        // TODO: Enforce invariants such as valid coordinates, non-empty name and address, etc.
        return new Location(name, address, latitude, longitude);
    }

    // Overrides the GetEqualityComponents method to define the components that are used for equality comparison.
    // In this case, the Name, Address, Latitude, and Longitude properties determine equality.
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longitude;
    }
}
