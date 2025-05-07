using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events;
public sealed class SaleCreatedEvent : DomainEvent
{
    public Guid SaleId { get; }

    public SaleCreatedEvent(Guid saleId)
    {
        SaleId = saleId;
    }
}
