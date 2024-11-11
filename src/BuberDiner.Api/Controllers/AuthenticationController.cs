using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDiner.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController(ISender mediator, IMapper mapper) : ApiController
    {
        #region Public methods declaration

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            RegisterCommand command = mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> authResult = await mediator.Send(command);

            return authResult.Match(
                value => Ok(mapper.Map<AuthenticationResponse>(value)),
                Problem
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Register([FromBody] LoginRequest request)
        {
            LoginQuery query = mapper.Map<LoginQuery>(request);
            ErrorOr<AuthenticationResult> authResult = await mediator.Send(query);
            return authResult.Match(
                value => Ok(mapper.Map<AuthenticationResponse>(value)),
                Problem);
        }

        #endregion
    }
}