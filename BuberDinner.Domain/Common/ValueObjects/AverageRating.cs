using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    #region Private constructors declaration

    private AverageRating(double value, int numRating)
    {
        Value = value;
        NumRating = numRating;
    }

    #endregion

    #region Public properties declaration

    public int NumRating { get; }

    public double Value { get; private set; }

    #endregion

    #region Public methods declaration

    public static AverageRating Create(double value = 0, int numRating = 0)
    {
        return new AverageRating(value, numRating);
    }

    public void AddNewRating(Rating rating)
    {
        Value = (Value * NumRating + rating.Value) / (NumRating + 1);
    }

    /// <inheritdoc />
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return NumRating;
    }

    public void RemoveRating(Rating rating)
    {
        Value = (Value * NumRating - rating.Value) / (NumRating - 1);
    }

    #endregion
}