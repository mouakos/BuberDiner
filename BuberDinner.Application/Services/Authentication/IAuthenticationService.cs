namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    Task<AuthenticationResult> RegisterAsync(string fistName, string lastname, string email, string password);
    Task<AuthenticationResult> LoginAsync(string email, string password);
}