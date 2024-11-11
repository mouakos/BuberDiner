using BuberDinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Queries.ListMenus;

public record ListMenusQuery(Guid HostId)
    : IRequest<ErrorOr<List<Menu>>>;