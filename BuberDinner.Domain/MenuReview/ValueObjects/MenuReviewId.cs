using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReview.ValueObjects;

public sealed class MenuReviewId : ValueObject
{
    #region Private constructors declaration

    private MenuReviewId(Guid value)
    {
        Value = value;
    }

    #endregion

    #region Public properties declaration

    public Guid Value { get; }

    #endregion

    #region Public methods declaration

    public static MenuReviewId CreateUnique()
    {
        return new MenuReviewId(Guid.NewGuid());
    }

    /// <inheritdoc />
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion
}