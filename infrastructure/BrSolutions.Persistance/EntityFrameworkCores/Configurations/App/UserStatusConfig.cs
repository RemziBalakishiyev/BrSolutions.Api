using BrSolution.Domain.Entities.App;
using BrSolution.Infrastructure.SqlHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrSolutions.Persistance.EntityFrameworkCores.Configurations.App;

public class UserStatusConfig :  EntityConfig<UserStatus>
{
    public override void Configure(EntityTypeBuilder<UserStatus> builder)
    {
        base.Configure(builder);

        ToIdentityPrimaryKey(builder, x => x.Id);
        builder.ToTable(TableName.UserStatuses, SchemaName.Libraries);
        builder.Property(x => x.Name)
            .HasMaxLength(20);
    }

}
