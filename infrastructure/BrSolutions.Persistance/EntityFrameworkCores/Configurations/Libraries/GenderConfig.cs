using BrSolution.Domain.Entities.Libraries;
using BrSolution.Infrastructure.SqlHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrSolutions.Persistance.EntityFrameworkCores.Configurations.Libraries;

public class GenderConfig :  EntityConfig<Gender>
{
    public override void Configure(EntityTypeBuilder<Gender> builder)
    {
        base.Configure(builder);
        builder.ToTable(TableName.Genders, SchemaName.Libraries);

        ToIdentityPrimaryKey(builder, x => x.Id);
        builder.Property(x => x.Name)
            .HasMaxLength(10);
    }
}
