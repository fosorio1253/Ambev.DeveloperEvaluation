using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Services.SaleServices;
public class SaleService : ISaleService
{
    public decimal CalculateDiscount(SaleItem item)
    {
        if (item.Quantity >= 10 && item.Quantity <= 20)
            return item.UnitPrice * item.Quantity * 0.20m;
        if (item.Quantity >= 4)
            return item.UnitPrice * item.Quantity * 0.10m;

        return 0m;
    }

    public void ValidateSaleItem(Sale sale, SaleItem item)
    {
        var sameProductItems = sale.SaleItems
            .Where(x => x.ProductId == item.ProductId
            && x.SaleItemStatus == SaleItemStatus.Active)
            .ToList();

        var totalQuantity = sameProductItems.Sum(x => x.Quantity) + item.Quantity;

        if (totalQuantity > 20)
            throw new DomainException($"Cannot add more than 20 items of the same product. Current total: {totalQuantity}");
    }
}