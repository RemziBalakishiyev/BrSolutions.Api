using BrSolution.Domain.Entities.App;
using BrSolution.Infrastructure.SqlHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrSolutions.Persistance.EntityFrameworkCores.Configurations.App;

public class CategoryConfig:UserRelatedEntityConfig<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.ToTable(TableName.Categories, SchemaName.App);
        ToIdentityPrimaryKey(builder, x => x.Id);

        builder.HasOne(x => x.Module)
            .WithMany()
            .HasForeignKey(x => x.ModuleId)
            .HasPrincipalKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
