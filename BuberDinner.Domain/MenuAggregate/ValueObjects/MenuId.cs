using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : ValueObject
{
    #region Private constructors declaration

    private MenuId(Guid value)
    {
        Value = value;
    }

    #endregion

    #region Public properties declaration

    public Guid Value { get; }

    #endregion

    #region Public methods declaration

    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }

    /// <inheritdoc />
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion
}