using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class ReservationId : ValueObject
{
    #region Private constructors declaration

    private ReservationId(Guid value)
    {
        Value = value;
    }

    #endregion

    #region Public properties declaration

    public Guid Value { get; }

    #endregion

    #region Public methods declaration

    public static ReservationId CreateUnique()
    {
        return new ReservationId(Guid.NewGuid());
    }

    /// <inheritdoc />
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion
}