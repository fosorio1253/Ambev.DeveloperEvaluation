using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Mapping.Base;
public abstract class AuditableEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property("CreatedAt").IsRequired();
        builder.Property("UpdatedAt").IsRequired(false);
        builder.Property("DeletedAt").IsRequired(false);
    }
}
