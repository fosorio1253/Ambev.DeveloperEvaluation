using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;
public interface ISaleRepository : IGenericRepository<Sale> { }

public class SaleRepository : GenericRepository<Sale>, ISaleRepository
{
    public SaleRepository(DefaultContext context) : base(context) { }
}