using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) : IAuthenticationService
{
    /// <inheritdoc />
    public async Task<AuthenticationResult> RegisterAsync(string fistName, string lastname, string email,
        string password)
    {
        // Check if user already exist


        // Create user (generate unique ID)


        // Create JWT token
        var userId = Guid.NewGuid();
        var token = jwtTokenGenerator.GenerateToken(userId, fistName, lastname);

        return new AuthenticationResult(userId, fistName, lastname, email, token);
    }

    /// <inheritdoc />
    public async Task<AuthenticationResult> LoginAsync(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "John", "Doe", email, "token");
    }
}