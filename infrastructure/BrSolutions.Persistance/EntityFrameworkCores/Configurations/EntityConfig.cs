using BrSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace BrSolutions.Persistance.EntityFrameworkCores.Configurations;

public abstract class EntityConfig<T> : IEntityTypeConfiguration<T>
 where T : class, IEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(x => x.CreateDate)
            .HasDefaultValueSql("GETDATE()");
    }

    protected void ToIdentityPrimaryKey(
        EntityTypeBuilder<T> builder,
        Expression<Func<T, object?>> propertySelector)
    {
        builder.Property(propertySelector)
            .ValueGeneratedOnAdd();

        builder.HasKey(propertySelector);
    }
}
