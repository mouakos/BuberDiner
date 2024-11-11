using BuberDinner.Domain.DinnerAggregate;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Dinners.Commands.CreateDinner;

public record CreateDinnerCommand(
    Guid HostId,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    bool IsPublic,
    int MaxGuests,
    DinnerPriceCommand Price,
    Guid MenuId,
    Uri ImageUrl,
    DinnerLocationCommand Location) : IRequest<ErrorOr<Dinner>>;

public record DinnerPriceCommand(
    decimal Amount,
    string Currency);

public record DinnerLocationCommand(
    string Name,
    string Address,
    double Latitude,
    double Longitude);