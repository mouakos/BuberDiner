using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    : IAuthenticationService
{
    /// <inheritdoc />
    public async Task<ErrorOr<AuthenticationResult>> RegisterAsync(string fistName, string lastname,
        string email,
        string password)
    {
        // Check if user already exist
        if (await userRepository.GetByEmailAsync(email) is not null)
            return Errors.User.DuplicateEmail;

        // Create user (generate unique ID)
        var user = new User { FirstName = fistName, LastName = lastname, Email = email, Password = password };
        await userRepository.AddAsync(user);


        // Create JWT token
        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    /// <inheritdoc />
    public async Task<ErrorOr<AuthenticationResult>> LoginAsync(string email, string password)
    {
        // Check if user exist
        var user = await userRepository.GetByEmailAsync(email);
        if (user is null)
            return Errors.Authentication.InvalidCredentials;

        // Check if password is correct
        if (user.Password != password)
            return Errors.Authentication.InvalidCredentials;

        // Create JWT token
        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}