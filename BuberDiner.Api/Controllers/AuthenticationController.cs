﻿using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDiner.Api.Controllers;

[Route("auth")]
public class AuthenticationController(ISender mediator, IMapper mapper) : ApiController
{
    #region Public methods declaration

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = mapper.Map<RegisterCommand>(request);
        var authResult = await mediator.Send(command);

        return authResult.Match(
            value => Ok(mapper.Map<AuthenticationResponse>(value)),
            Problem
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Register([FromBody] LoginRequest request)
    {
        var query = mapper.Map<LoginQuery>(request);
        var authResult = await mediator.Send(query);
        return authResult.Match(
            value => Ok(mapper.Map<AuthenticationResponse>(value)),
            Problem);
    }

    #endregion
}