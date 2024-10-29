using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDiner.Api.Controllers;

[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var authResult =
            await authenticationService.RegisterAsync(request.FirstName, request.LastName, request.Email,
                request.Password);

        return authResult.Match(
            value => Ok(MapAuthResult(value)),
            Problem
        );
    }

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

    [HttpPost("login")]
    public async Task<IActionResult> Register([FromBody] LoginRequest request)
    {
        var authResult = await authenticationService.LoginAsync(request.Email, request.Password);
        return authResult.Match(
            value => Ok(MapAuthResult(value)),
            Problem);
    }
}