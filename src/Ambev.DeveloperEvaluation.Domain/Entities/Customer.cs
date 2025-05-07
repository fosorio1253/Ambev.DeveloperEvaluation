using System.Text.RegularExpressions;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;
public class Customer : BaseEntity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string? Phone { get; private set; }

    protected Customer() { }

    public Customer(Guid id, string name, string email, string? phone = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Customer name is required.");

        if (string.IsNullOrWhiteSpace(email)
            || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new DomainException("Invalid email format.");

        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
        CreatedAt = DateTime.UtcNow;
    }
}