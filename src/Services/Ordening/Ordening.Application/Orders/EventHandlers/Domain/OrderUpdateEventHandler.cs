namespace Ordening.Application.Orders.EventHandlers.Domain;

public class OrderUpdateEventHandler(ILogger<OrderUpdateEventHandler> logger)
    : INotificationHandler<OrderUpdateEvent>
{
    public Task Handle(OrderUpdateEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handler: {DomainEvent}", notification.GetType());

        return Task.CompletedTask;
    }
}
