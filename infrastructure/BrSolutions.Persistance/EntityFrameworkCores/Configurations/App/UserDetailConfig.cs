using BrSolution.Domain.Entities.App;
using BrSolution.Infrastructure.SqlHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrSolutions.Persistance.EntityFrameworkCores.Configurations.App;

public class UserDetailConfig : EntityConfig<UserDetail>
{
    public override void Configure(EntityTypeBuilder<UserDetail> builder)
    {
        base.Configure(builder);
        ToIdentityPrimaryKey(builder, x => x.Id);

        builder.ToTable(TableName.UserDetails, SchemaName.App);

        builder.Property(x => x.FirstName)
            .HasMaxLength(30);

        builder.Property(x => x.LastName)
            .HasMaxLength(30);

        builder.Property(x => x.DateOfBirth);

        builder.HasOne(x => x.User)
            .WithOne(x=>x.UserDetail)
            .HasForeignKey<UserDetail>(x => x.UserId)
            .HasPrincipalKey<User>(x => x.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x=>x.UploadedFile)
            .WithOne()
            .HasForeignKey<UserDetail>(x=>x.UploadFileId)
            .HasPrincipalKey<UploadFile>(x=>x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Gender)
            .WithMany()
            .HasForeignKey(x => x.GenderId);




    }
}
