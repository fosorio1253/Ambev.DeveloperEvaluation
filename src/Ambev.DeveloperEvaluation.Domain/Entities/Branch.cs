using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;
public class Branch : BaseEntity
{
    public string Name { get; private set; }
    public string Address { get; private set; }

    protected Branch() { }

    public Branch(Guid id, string name, string address)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Branch name is required.");

        Id = id;
        Name = name;
        Address = address;
        CreatedAt = DateTime.UtcNow;
    }
}