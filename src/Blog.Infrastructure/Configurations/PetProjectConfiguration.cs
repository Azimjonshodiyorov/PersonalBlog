
using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations;

public class PetProjectConfiguration : IEntityTypeConfiguration<PetProject>
{
    public void Configure(EntityTypeBuilder<PetProject> builder)
    {
        builder
            .HasMany(x => x.PetProjectFiles)
            .WithOne(x => x.PetProject)
            .HasForeignKey(x => x.OwnerId);
    }
}
