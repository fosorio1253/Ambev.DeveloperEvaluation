using Ambev.DeveloperEvaluation.Domain.Entities;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;
public class ActiveSaleSpecification
{
    public static Expression<Func<Sale, bool>> Criteria => sale => !sale.IsCancelled;
}