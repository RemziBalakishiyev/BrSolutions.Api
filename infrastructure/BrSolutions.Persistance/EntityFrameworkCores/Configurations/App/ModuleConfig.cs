using BrSolution.Domain.Entities.App;
using BrSolution.Infrastructure.SqlHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrSolutions.Persistance.EntityFrameworkCores.Configurations.App;

public class ModuleConfig : UserRelatedEntityConfig<Module>
{
    public override void Configure(EntityTypeBuilder<Module> builder)
    {
        base.Configure(builder);

        builder.ToTable(TableName.Modules, SchemaName.App);

        builder.Property(x => x.Name)
            .HasMaxLength(60);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .HasPrincipalKey(x => x.Id);
    }
}
