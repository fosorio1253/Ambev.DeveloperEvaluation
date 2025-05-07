using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events;
public sealed class ItemCancelledEvent : DomainEvent
{
    public Guid SaleItemId { get; }

    public ItemCancelledEvent(Guid saleItemId)
    {
        SaleItemId = saleItemId;
    }
}