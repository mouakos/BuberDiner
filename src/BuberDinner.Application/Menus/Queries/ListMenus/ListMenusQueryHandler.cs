using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Queries.ListMenus;

public class ListMenusQueryHandler(IMenuRepository menuRepository)
    : IRequestHandler<ListMenusQuery, ErrorOr<List<Menu>>>
{
    public async Task<ErrorOr<List<Menu>>> Handle(ListMenusQuery query, CancellationToken cancellationToken)
    {
        var hostId = HostId.Create(query.HostId);

        return await menuRepository.ListAsync(hostId);
    }
}