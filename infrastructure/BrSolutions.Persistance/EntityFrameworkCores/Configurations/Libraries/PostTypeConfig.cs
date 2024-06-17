using BrSolution.Domain.Entities.Libraries;
using BrSolution.Infrastructure.SqlHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrSolutions.Persistance.EntityFrameworkCores.Configurations.Libraries;

public class PostTypeConfig : EntityConfig<PostType>
{
    public override void Configure(EntityTypeBuilder<PostType> builder)
    {
        base.Configure(builder);
        builder.ToTable(TableName.PostTypes, SchemaName.Libraries);

        ToIdentityPrimaryKey(builder, x => x.Id);
        builder.Property(x => x.Name)
            .HasMaxLength(30);
    }
}
