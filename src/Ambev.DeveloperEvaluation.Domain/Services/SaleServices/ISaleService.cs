using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Services.SaleServices;
public interface ISaleService
{
    decimal CalculateDiscount(SaleItem item);
    void ValidateSaleItem(Sale sale, SaleItem item);
}