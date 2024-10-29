using BuberDiner.Api.Filters;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDiner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var result =
            await authenticationService.RegisterAsync(request.FirstName, request.LastName, request.Email,
                request.Password);
        var response = new AuthenticationResponse
        (
            result.User.Id,
            result.User.FirstName,
            result.User.LastName,
            result.User.Email,
            result.Token
        );
        return Ok(response);
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Register([FromBody] LoginRequest request)
    {
        var result = await authenticationService.LoginAsync(request.Email, request.Password);
        var response = new AuthenticationResponse
        (
            result.User.Id,
            result.User.FirstName,
            result.User.LastName,
            result.User.Email,
            result.Token
        );
        return Ok(response);
    }
}