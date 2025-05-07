using System.Linq.Expressions;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ActiveUserSpecification : ISpecification<User>
{
    public Expression<Func<User, bool>>? Criteria => throw new NotImplementedException();

    public List<Expression<Func<User, object>>> Includes => throw new NotImplementedException();

    public Expression<Func<User, object>>? OrderBy => throw new NotImplementedException();

    public Expression<Func<User, object>>? OrderByDescending => throw new NotImplementedException();

    public bool IsTracking => throw new NotImplementedException();

    public bool IsSatisfiedBy(User user)
    {
        return user.Status == UserStatus.Active;
    }
}
