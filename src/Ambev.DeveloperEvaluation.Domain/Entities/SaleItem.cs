using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Domain.Entities;
public class SaleItem : AggregateRoot
{
    public Guid SaleId { get; private set; }
    public Guid ProductId { get; private set; }
    public string ProductName { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Discount { get; private set; }
    public decimal TotalAmount => (Quantity * UnitPrice) - Discount;
    public SaleItemStatus SaleItemStatus { get; private set; }

    protected SaleItem() { }

    public SaleItem(
        Guid id,
        Guid saleId,
        Guid productId,
        string productName,
        int quantity,
        decimal unitPrice)
    {
        if (quantity < 1 || quantity > 20)
            throw new DomainException("Quantity must be between 1 and 20.");

        if (unitPrice <= 0)
            throw new DomainException("UnitPrice must be greater than zero.");

        Id = id;
        SaleId = saleId;
        ProductId = productId;
        ProductName = productName;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = 0;
        SaleItemStatus = SaleItemStatus.Active;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = null;
    }

    public void ApplyDiscount(decimal discount)
    {
        if (discount < 0 || discount > Quantity * UnitPrice)
            throw new DomainException("Invalid discount value.");

        Discount = discount;
        UpdatedAt = DateTime.UtcNow;
    }

    public void CancelItem()
    {
        if (SaleItemStatus == SaleItemStatus.Cancelled) return;

        SaleItemStatus = SaleItemStatus.Cancelled;
        UpdatedAt = DateTime.UtcNow;
        AddDomainEvent(new ItemCancelledEvent(Id));
    }
}