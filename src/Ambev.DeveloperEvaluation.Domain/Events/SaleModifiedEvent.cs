using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events;
public sealed class SaleModifiedEvent : DomainEvent
{
    public Guid SaleId { get; }

    public SaleModifiedEvent(Guid saleId)
    {
        SaleId = saleId;
    }
}