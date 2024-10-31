using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    #region Private constructors declaration

    private Rating(double value)
    {
        Value = value;
    }

    #endregion

    #region Public properties declaration

    public double Value { get; }

    #endregion

    #region Public methods declaration

    public static Rating Create(double value)
    {
        return new Rating(value);
    }

    /// <inheritdoc />
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion
}