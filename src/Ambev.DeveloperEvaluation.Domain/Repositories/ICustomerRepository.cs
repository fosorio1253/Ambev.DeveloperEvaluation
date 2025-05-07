using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;
public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(Guid id);
    Task AddAsync(Customer customer);
}