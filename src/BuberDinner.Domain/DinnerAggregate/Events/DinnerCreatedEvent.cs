using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.Events;

public record DinnerCreatedEvent(Dinner Dinner) : IDomainEvent;