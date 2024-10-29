using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    Task<ErrorOr<AuthenticationResult>> RegisterAsync(string fistName, string lastname,
        string email, string password);

    Task<ErrorOr<AuthenticationResult>> LoginAsync(string email, string password);
}