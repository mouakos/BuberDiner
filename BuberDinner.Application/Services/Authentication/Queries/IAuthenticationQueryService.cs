using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    #region Public methods declaration

    Task<ErrorOr<AuthenticationResult>> LoginAsync(string email, string password);

    #endregion
}