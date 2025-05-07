using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;
public class Product : BaseEntity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }

    protected Product() { }

    public Product(Guid id, string name, decimal price, string? description = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Product name is required.");

        if (price <= 0)
            throw new DomainException("Price must be greater than zero.");

        Id = id;
        Name = name;
        Price = price;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }
}