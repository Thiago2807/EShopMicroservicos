namespace Ordening.Domain.Events;

public record OrderCreatedEvent(Order Order) : IDomainEvent;
