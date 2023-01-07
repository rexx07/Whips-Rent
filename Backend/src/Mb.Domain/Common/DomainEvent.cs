namespace Mb.Domain.Common;

public interface IHasDomainEvent
{
    List<DomainEvent> DomainEvents { get; set; }
}

public abstract class DomainEvent
{
    protected DomainEvent()
    {
        DateOccured = DateTimeOffset.Now;
    }

    public DateTimeOffset DateOccured { get; protected set; }
    public bool IsPublished { get; set; }
}