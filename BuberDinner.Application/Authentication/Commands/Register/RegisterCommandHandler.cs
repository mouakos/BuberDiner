using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    #region Public methods declaration

    /// <inheritdoc />
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command,
        CancellationToken cancellationToken)
    {
        // Check if user already exist
        if (await userRepository.GetByEmailAsync(command.Email) is not null)
            return Errors.User.DuplicateEmail;

        // Create user (generate unique ID)
        var user = new User
        {
            FirstName = command.FirstName, LastName = command.LastName, Email = command.Email,
            Password = command.Password
        };
        await userRepository.AddAsync(user);


        // Create JWT token
        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    #endregion
}