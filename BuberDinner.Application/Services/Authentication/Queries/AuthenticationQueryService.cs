using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Queries;

public class AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    : IAuthenticationQueryService
{
    #region Public methods declaration

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

    #endregion
}