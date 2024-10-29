using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDiner.Api.Controllers;

[Route("auth")]
public class AuthenticationController(ISender mediator) : ApiController
{
    #region Public methods declaration

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email,
            request.Password);
        var authResult = await mediator.Send(command);

        return authResult.Match(
            value => Ok(MapAuthResult(value)),
            Problem
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Register([FromBody] LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var authResult = await mediator.Send(query);
        return authResult.Match(
            value => Ok(MapAuthResult(value)),
            Problem);
    }

    #endregion

    #region Private methods declaration

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authenticationResult)
    {
        return new AuthenticationResponse
        (
            authenticationResult.User.Id,
            authenticationResult.User.FirstName,
            authenticationResult.User.LastName,
            authenticationResult.User.Email,
            authenticationResult.Token
        );
    }

    #endregion
}