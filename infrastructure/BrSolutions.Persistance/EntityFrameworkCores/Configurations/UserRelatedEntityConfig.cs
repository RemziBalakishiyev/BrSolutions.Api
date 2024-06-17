using BrSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BrSolutions.Persistance.EntityFrameworkCores.Configurations;

public abstract class UserRelatedEntityConfig<T> : UserCreatedEntityConfig<T>
    where T : class, IEditedRelatableUserEntity
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.LastEditUser)
            .WithMany()
            .HasForeignKey(x => x.LastEditUserId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
