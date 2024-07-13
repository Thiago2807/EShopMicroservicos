namespace BuildingBlocks.Messaging.Events;

public record IntegrationEvent
{
    public Guid Id => Guid.NewGuid();
    public DateTime OccurrendOn = DateTime.Now;
    public string EventType => GetType().AssemblyQualifiedName;
}
