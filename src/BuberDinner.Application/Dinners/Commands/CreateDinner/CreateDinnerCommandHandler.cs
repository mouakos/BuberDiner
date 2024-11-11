using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Common.DomainErrors;
using BuberDinner.Domain.DinnerAggregate;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Commands.CreateDinner;

public class CreateDinnerCommandHandler(IDinnerRepository dinnerRepository, IMenuRepository menuRepository)
    : IRequestHandler<CreateDinnerCommand, ErrorOr<Dinner>>
{
    public async Task<ErrorOr<Dinner>> Handle(CreateDinnerCommand command, CancellationToken cancellationToken)
    {
        var menuId = MenuId.Create(command.MenuId);

        if (!await menuRepository.ExistsAsync(menuId))
        {
            return Errors.Menu.NotFound;
        }

        var dinner = Dinner.Create(
            command.Name,
            command.Description,
            command.StartDateTime,
            command.EndDateTime,
            command.IsPublic,
            command.MaxGuests,
            Price.Create(
                command.Price.Amount,
                command.Price.Currency),
            menuId,
            HostId.Create(command.HostId),
            command.ImageUrl,
            Location.Create(
                command.Location.Name,
                command.Location.Address,
                command.Location.Latitude,
                command.Location.Longitude));

        await dinnerRepository.AddAsync(dinner);

        return dinner;
    }
}