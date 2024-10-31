using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class Price : ValueObject
{
    #region Private constructors declaration

    private Price(decimal value, string currency)
    {
        Value = value;
        Currency = currency;
    }

    #endregion

    #region Public properties declaration

    public string Currency { get; }

    public decimal Value { get; }

    #endregion

    #region Public methods declaration

    public static Price Create(decimal value, string currency)
    {
        return new Price(value, currency);
    }

    /// <inheritdoc />
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Currency;
    }

    #endregion
}