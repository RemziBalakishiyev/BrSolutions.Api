using BrSolution.Domain.Entities.App;
using BrSolution.Infrastructure.SqlHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrSolutions.Persistance.EntityFrameworkCores.Configurations.App
{
    public class SystemServiceConfig :  EntityConfig<SystemService>
    {
        public override void Configure(EntityTypeBuilder<SystemService> builder)
        {
            base.Configure(builder);
            builder.ToTable(TableName.SystemServices, SchemaName.App);

            ToIdentityPrimaryKey(builder, x => x.Id);

            builder.Property(x => x.EncryptedName)
               .HasMaxLength(64);

            builder.HasIndex(x => x.EncryptedName)
                .IsUnique();
        }
    }
}
