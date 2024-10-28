namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    /// <inheritdoc />
    public async Task<AuthenticationResult> RegisterAsync(string fistName, string lastname, string email,
        string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), fistName, lastname, email, "token");
    }

    /// <inheritdoc />
    public async Task<AuthenticationResult> LoginAsync(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "John", "Doe", email, "token");
    }
}