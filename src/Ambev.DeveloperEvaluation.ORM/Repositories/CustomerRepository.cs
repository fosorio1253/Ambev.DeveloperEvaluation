using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;
public interface ICustomerRepository : IGenericRepository<Customer> { }

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(DefaultContext context) : base(context) { }
}