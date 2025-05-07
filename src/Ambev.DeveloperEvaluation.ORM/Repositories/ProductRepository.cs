using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;
public interface IProductRepository : IGenericRepository<Product> { }

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(DefaultContext context) : base(context) { }
}