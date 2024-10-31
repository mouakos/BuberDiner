using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class Location : ValueObject
{
    #region Private constructors declaration

    private Location(string name, string address, double latitude, double longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    #endregion

    #region Public properties declaration

    public string Address { get; }
    public double Latitude { get; }
    public double Longitude { get; }
    public string Name { get; }

    #endregion

    #region Public methods declaration

    public static Location Create(
        string name,
        string address,
        double latitude,
        double longitude)
    {
        return new Location(
            name,
            address,
            latitude,
            longitude);
    }

    /// <inheritdoc />
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Latitude;
        yield return Longitude;
        yield return Name;
        yield return Address;
    }

    #endregion
}