using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrSolution.Domain.Entities;

namespace BrSolutions.Persistance.EntityFrameworkCores.Configurations;

public  abstract class UserCreatedEntityConfig<T> : EntityConfig<T>
 where T : class, ICreatedUserEntity
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.CreatedUser)
            .WithMany()
            .HasForeignKey(x => x.CreatedUserId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
