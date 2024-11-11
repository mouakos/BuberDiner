namespace BuberDinner.Application.Common.Services;

public interface IDateTimeProvider
{
    #region Public properties declaration

    DateTime UtcNow { get; }

    #endregion
}