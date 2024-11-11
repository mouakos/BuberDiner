using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        #region Public methods declaration

        /// <inheritdoc />
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            // Check if user exist
            User? user = await userRepository.GetByEmailAsync(query.Email);
            if (user is null)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // Check if password is correct
            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // Create JWT token
            string token = jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }

        #endregion
    }
}