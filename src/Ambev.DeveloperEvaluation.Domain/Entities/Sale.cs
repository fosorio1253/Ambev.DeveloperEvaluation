using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Events;

namespace Ambev.DeveloperEvaluation.Domain.Entities;
public class Sale : AggregateRoot
{
    private readonly List<SaleItem> _saleItems = new();

    public string SaleNumber { get; private set; }
    public DateTime SaleDate { get; private set; }

    public Guid CustomerId { get; private set; }
    public string CustomerName { get; private set; }

    public Guid BranchId { get; private set; }
    public string BranchName { get; private set; }

    public decimal TotalAmount { get; private set; }
    public SaleStatus SaleStatus { get; private set; }

    public IReadOnlyCollection<SaleItem> SaleItems => _saleItems.AsReadOnly();

    protected Sale() { } // EF Core

    public Sale(Guid id, string saleNumber, DateTime saleDate, Guid customerId, string customerName,
        Guid branchId, string branchName)
    {
        if (string.IsNullOrWhiteSpace(saleNumber))
            throw new DomainException("SaleNumber is required.");

        if (saleDate.Date > DateTime.UtcNow.Date)
            throw new DomainException("SaleDate cannot be in the future.");

        Id = id;
        SaleNumber = saleNumber;
        SaleDate = saleDate;
        CustomerId = customerId;
        CustomerName = customerName;
        BranchId = branchId;
        BranchName = branchName;
        SaleStatus = SaleStatus.Active;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = null;

        AddDomainEvent(new SaleCreatedEvent(Id));
    }

    public void AddSaleItem(SaleItem item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));

        if (SaleStatus == SaleStatus.Cancelled)
            throw new DomainException("Cannot add item to a cancelled sale.");

        _saleItems.Add(item);
        RecalculateTotal();
        UpdatedAt = DateTime.UtcNow;
        AddDomainEvent(new SaleModifiedEvent(Id));
    }

    public void Cancel()
    {
        if (SaleStatus == SaleStatus.Cancelled)
            throw new DomainException("Sale already cancelled.");

        SaleStatus = SaleStatus.Cancelled;
        UpdatedAt = DateTime.UtcNow;

        foreach (var item in _saleItems)
        {
            item.CancelItem(); // dispara evento de cancelamento por item
        }

        AddDomainEvent(new SaleCancelledEvent(Id));
    }

    public void RecalculateTotal()
    {
        TotalAmount = _saleItems
            .Where(i => i.SaleItemStatus == SaleItemStatus.Active)
            .Sum(i => i.TotalAmount);
    }

    public void Validate()
    {
        if (!_saleItems.Any())
            throw new DomainException("A sale must contain at least one item.");

        if (SaleDate.Date > DateTime.UtcNow.Date)
            throw new DomainException("SaleDate cannot be in the future.");
    }
}