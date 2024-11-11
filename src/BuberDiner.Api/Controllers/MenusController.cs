using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.MenuAggregate;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDiner.Api.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenusController(IMapper mapper, ISender mediator) : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateMenuAsync([FromRoute] string hostId,
            [FromBody] CreateMenuRequest request)
        {
            CreateMenuCommand command = mapper.Map<CreateMenuCommand>(request);
            ErrorOr<Menu> createMenuResult = await mediator.Send(command);

            return createMenuResult.Match(
                value => Ok(mapper.Map<MenuResponse>(value)),
                Problem
            );
        }
    }
}