using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    #region Public methods declaration

    /// <inheritdoc />
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // Check if user exist
        var user = await userRepository.GetByEmailAsync(query.Email);
        if (user is null)
            return Errors.Authentication.InvalidCredentials;

        // Check if password is correct
        if (user.Password != query.Password)
            return Errors.Authentication.InvalidCredentials;

        // Create JWT token
        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    #endregion
}