using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.Events;

public record MenuCreatedEvent(Menu Menu) : IDomainEvent;