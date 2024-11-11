using BuberDinner.Application.Dinners.Commands.CreateDinner;
using BuberDinner.Application.Dinners.Queries.ListDinners;
using BuberDinner.Contracts.Dinners;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDiner.Api.Controllers
{
    [Route("hosts/{hostId:guid}/[controller]")]
    public class DinnersController(IMapper mapper, ISender mediator) : ApiController
    {
        #region Public methods declaration

        [HttpPost]
        public async Task<IActionResult> CreateDinner(CreateDinnerRequest request, Guid hostId)
        {
            var command = mapper.Map<CreateDinnerCommand>((request, hostId));

            var createDinnerResult = await mediator.Send(command);

            return createDinnerResult.Match(
                dinner => Ok(mapper.Map<DinnerResponse>(dinner)),
                Problem);
        }

        [HttpGet]
        public async Task<IActionResult> ListDinners(Guid hostId)
        {
            var query = mapper.Map<ListDinnersQuery>(hostId);

            var listDinnersQuery = await mediator.Send(query);

            return listDinnersQuery.Match(
                dinners => Ok(dinners.Select(mapper.Map<DinnerResponse>)),
                Problem);
        }

        #endregion
    }
}