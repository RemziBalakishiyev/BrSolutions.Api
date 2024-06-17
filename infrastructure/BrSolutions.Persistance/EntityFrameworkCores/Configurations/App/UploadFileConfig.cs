using BrSolution.Domain.Entities.App;
using BrSolution.Infrastructure.SqlHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrSolutions.Persistance.EntityFrameworkCores.Configurations.App;

public class UploadFileConfig :  UserRelatedEntityConfig<UploadFile>
{
    public override void Configure(EntityTypeBuilder<UploadFile> builder)
    {
        base.Configure(builder);

        builder.ToTable(TableName.UploadFile, SchemaName.App);

        ToIdentityPrimaryKey(builder, x => x.Id);
        builder.Property(x => x.FileName)
            .HasMaxLength(256);

        builder.Property(x => x.RelativePath);
            
    }
}
