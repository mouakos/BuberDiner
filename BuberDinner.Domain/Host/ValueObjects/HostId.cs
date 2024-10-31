using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Host.ValueObjects;

public sealed class HostId : ValueObject
{
    #region Private constructors declaration

    private HostId(Guid value)
    {
        Value = value;
    }

    #endregion

    #region Public properties declaration

    public Guid Value { get; }

    #endregion

    #region Public methods declaration

    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }

    /// <inheritdoc />
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion
}