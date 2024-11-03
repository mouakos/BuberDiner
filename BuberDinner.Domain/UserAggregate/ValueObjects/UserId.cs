using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.UserAggregate.ValueObjects;

public class UserId : ValueObject
{
    #region Private constructors declaration

    private UserId(Guid value)
    {
        Value = value;
    }

    #endregion

    #region Public properties declaration

    public Guid Value { get; }

    #endregion

    #region Public methods declaration

    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion
}