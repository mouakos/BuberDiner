using BuberDinner.Domain.DinnerAggregate;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Queries.ListDinners;

public record ListDinnersQuery(Guid HostId) : IRequest<ErrorOr<List<Dinner>>>;