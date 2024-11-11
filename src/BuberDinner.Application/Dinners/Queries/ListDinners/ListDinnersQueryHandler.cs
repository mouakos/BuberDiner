using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.DinnerAggregate;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Queries.ListDinners;

public class ListDinnersQueryHandler(IDinnerRepository dinnerRepository)
    : IRequestHandler<ListDinnersQuery, ErrorOr<List<Dinner>>>
{
    public async Task<ErrorOr<List<Dinner>>> Handle(ListDinnersQuery request, CancellationToken cancellationToken)
    {
        var hostId = HostId.Create(request.HostId);
        return await dinnerRepository.ListAsync(hostId);
    }
}