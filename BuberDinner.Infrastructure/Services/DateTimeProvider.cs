using BuberDinner.Application.Common.Services;

namespace BuberDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    /// <inheritdoc />
    public DateTime UtcNow => DateTime.UtcNow;
}