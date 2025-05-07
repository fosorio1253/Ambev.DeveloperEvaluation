using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events;
public sealed class SaleCancelledEvent : DomainEvent
{
    public Guid SaleId { get; }

    public SaleCancelledEvent(Guid saleId)
    {
        SaleId = saleId;
    }
}