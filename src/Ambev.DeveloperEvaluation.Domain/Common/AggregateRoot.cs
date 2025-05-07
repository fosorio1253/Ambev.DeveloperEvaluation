using System.Collections.ObjectModel;

namespace Ambev.DeveloperEvaluation.Domain.Common;
public abstract class AggregateRoot : BaseEntity, IAggregateRoot
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public ReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}