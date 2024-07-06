namespace Ordening.Domain.Events;

public record OrderUpdateEvent(Order Order) : IDomainEvent;
