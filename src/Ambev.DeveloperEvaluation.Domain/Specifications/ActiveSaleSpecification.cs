using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;
public class ActiveSaleSpecification
{
    public static Expression<Func<Sale, SaleStatus>> Criteria
        => sale => sale.SaleStatus;
}