using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    #region Private constructors declaration

    private AverageRating(double value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }

    #endregion

    #region Public properties declaration

    public int NumRatings { get; private set; }

    public double Value { get; private set; }

    #endregion

    #region Public methods declaration

    public static AverageRating Create(double value = 0, int numRating = 0)
    {
        return new AverageRating(value, numRating);
    }

    public void AddNewRating(Rating rating)
    {
        Value = (Value * NumRatings + rating.Value) / ++NumRatings;
    }

    /// <inheritdoc />
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return NumRatings;
    }

    public void RemoveRating(Rating rating)
    {
        Value = (Value * NumRatings - rating.Value) / --NumRatings;
    }

    #endregion
}