using BrSolution.Domain.Entities.App;
using BrSolution.Infrastructure.SqlHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrSolutions.Persistance.EntityFrameworkCores.Configurations.App;

public class UserConfig : EntityConfig<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        builder.ToTable(TableName.Users, SchemaName.App);

        ToIdentityPrimaryKey(builder, x => x.Id);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasMaxLength(128);

        builder.HasOne(x => x.UserStatus)
            .WithMany()
            .HasForeignKey(x => x.UserStatusId);
    }
}
