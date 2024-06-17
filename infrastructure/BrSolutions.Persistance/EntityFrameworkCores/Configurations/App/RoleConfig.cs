using BrSolution.Domain.Entities.App;
using BrSolution.Infrastructure.SqlHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrSolutions.Persistance.EntityFrameworkCores.Configurations.App;

public class RoleConfig : UserRelatedEntityConfig<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        base.Configure(builder);

        builder.ToTable(TableName.Roles, SchemaName.App);
    
        ToIdentityPrimaryKey(builder, x => x.Id);

        builder.Property(x => x.RoleName)
            .HasMaxLength(40)
            .IsRequired();

        builder.HasOne(x => x.SystemService)
            .WithMany()
            .HasForeignKey(x => x.SystemServiceId)
            .HasPrincipalKey(x => x.Id);
    }
}
