using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Events;
using MediatR;

namespace BuberDinner.Application.Menus.Events;

public class MenuCreatedEventHandler : INotificationHandler<MenuCreatedEvent>
{
    /// <inheritdoc />
    public Task Handle(MenuCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}