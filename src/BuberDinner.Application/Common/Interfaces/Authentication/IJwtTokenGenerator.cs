using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    #region Public methods declaration

    string GenerateToken(User user);

    #endregion
}