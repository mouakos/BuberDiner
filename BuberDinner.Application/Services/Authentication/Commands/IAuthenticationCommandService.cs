using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    #region Public methods declaration

    Task<ErrorOr<AuthenticationResult>> RegisterAsync(string fistName, string lastname,
        string email,
        string password);

    #endregion
}