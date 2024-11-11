using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.DinnerAggregate.Events;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using MediatR;

namespace BuberDinner.Application.Dinners.Events;

public class DinnerCreatedEventHandler(IMenuRepository menuRepository) : INotificationHandler<DinnerCreatedEvent>
{
    /// <inheritdoc />
    public async Task Handle(DinnerCreatedEvent notification, CancellationToken cancellationToken)
    {
        if (await menuRepository.GetByIdAsync(notification.Dinner.MenuId) is not Menu menu)
        {
            throw new InvalidOperationException(
                $"Dinner has invalid menu id (dinner id: {notification.Dinner.Id}, menu id: {notification.Dinner.MenuId}).");
        }

        menu.AddDinnerId((DinnerId)notification.Dinner.Id);

        await menuRepository.UpdateAsync(menu);
    }
}