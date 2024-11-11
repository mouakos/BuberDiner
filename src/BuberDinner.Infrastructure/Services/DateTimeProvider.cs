using BuberDinner.Application.Common.Services;

namespace BuberDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    #region Public properties declaration

    /// <inheritdoc />
    public DateTime UtcNow => DateTime.UtcNow;

    #endregion
}