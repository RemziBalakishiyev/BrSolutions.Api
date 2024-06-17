using BrSolution.Domain.Entities.Libraries;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrSolutions.Persistance.EntityFrameworkCores.Configurations.Libraries;

public class PostStatusConfig : EntityConfig<PostStatus>
{
    public override void Configure(EntityTypeBuilder<PostStatus> builder)
    {
        base.Configure(builder);

        ToIdentityPrimaryKey(builder,x=>x.Id);
        builder.Property(x => x.Name)
            .HasMaxLength(20);
    }
}
