using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    : IAuthenticationService
{
    /// <inheritdoc />
    public async Task<AuthenticationResult> RegisterAsync(string fistName, string lastname, string email,
        string password)
    {
        // Check if user already exist
        if (await userRepository.GetByEmailAsync(email) is not null)
            throw new Exception("User already exist");

        // Create user (generate unique ID)
        var user = new User { FirstName = fistName, LastName = lastname, Email = email, Password = password };
        await userRepository.AddAsync(user);


        // Create JWT token
        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    /// <inheritdoc />
    public async Task<AuthenticationResult> LoginAsync(string email, string password)
    {
        // Check if user exist
        var user = await userRepository.GetByEmailAsync(email);
        if (user is null)
            throw new Exception("User with given email dest not exist.");

        // Check if password is correct
        if (user.Password != password)
            throw new Exception("Invalid password");

        // Create JWT token
        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}