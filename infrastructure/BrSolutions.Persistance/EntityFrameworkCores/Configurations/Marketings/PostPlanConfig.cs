using BrSolution.Domain.Entities.Marketing;
using BrSolution.Infrastructure.SqlHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrSolutions.Persistance.EntityFrameworkCores.Configurations.Marketings;

public class PostPlanConfig : UserRelatedEntityConfig<PostPlan>
{
    public override void Configure(EntityTypeBuilder<PostPlan> builder)
    {
        base.Configure(builder);
        builder.ToTable(TableName.PostPlans, SchemaName.App);
        ToIdentityPrimaryKey(builder, x => x.Id);

        builder.Property(x => x.Caption)
            .HasColumnType(SqlType.nText);

        builder.Property(x => x.Description)
            .HasColumnType(SqlType.nText);

        builder.Property(x => x.Definition)
            .HasMaxLength(64);

   

        builder.HasOne(x => x.PostStatus)
            .WithMany()
            .HasForeignKey(x => x.PostStatusId)
            .HasPrincipalKey(x => x.Id);

        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId)
            .HasPrincipalKey(x => x.Id);
    }
}
