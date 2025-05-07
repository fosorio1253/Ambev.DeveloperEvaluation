using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;
public interface IBranchRepository : IGenericRepository<Branch> { }

public class BranchRepository : GenericRepository<Branch>, IBranchRepository
{
    public BranchRepository(DefaultContext context) : base(context) { }
}