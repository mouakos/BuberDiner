using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Commands;

public class AuthenticationCommandService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    : IAuthenticationCommandService
{
    #region Public methods declaration

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

    #endregion
}