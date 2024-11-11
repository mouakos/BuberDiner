using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.Menus.Queries.ListMenus;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.MenuAggregate;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDiner.Api.Controllers
{
    [Route("hosts/{hostId:guid}/menus")]
    public class MenusController(IMapper mapper, ISender mediator) : ApiController
    {
        #region Public methods declaration

        [HttpPost]
        public async Task<IActionResult> CreateMenuAsync(Guid hostId, CreateMenuRequest request)
        {
            CreateMenuCommand command = mapper.Map<CreateMenuCommand>((request, hostId));
            ErrorOr<Menu> createMenuResult = await mediator.Send(command);

            return createMenuResult.Match(
                value => Ok(mapper.Map<MenuResponse>(value)),
                Problem
            );
        }

        [HttpGet]
        public async Task<IActionResult> ListMenus(Guid hostId)
        {
            var query = mapper.Map<ListMenusQuery>(hostId);

            var listMenusResult = await mediator.Send(query);

            return listMenusResult.Match(
                menus => Ok(menus.Select(mapper.Map<MenuResponse>)),
                Problem);
        }

        #endregion
    }
}