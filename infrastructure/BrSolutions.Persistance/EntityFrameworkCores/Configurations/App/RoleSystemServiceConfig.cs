using BrSolution.Domain.Entities.App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrSolutions.Persistance.EntityFrameworkCores.Configurations.App
{
    public class RoleSystemServiceConfig : EntityConfig<RoleSystemService>
    {
        public override void Configure(EntityTypeBuilder<RoleSystemService> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => new { x.RoleId, x.SystemServiceId });

            builder.HasOne(x => x.Role)
            .WithMany(x => x.RoleSystemServices)
            .HasForeignKey(x => x.RoleId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.SystemService)
           .WithMany(x=>x.RoleSystemServices)
           .HasForeignKey(x => x.SystemServiceId)
           .HasPrincipalKey(x => x.Id)
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
