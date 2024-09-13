
using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations;

public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder
            .HasMany(x => x.CertificateFiles)
            .WithOne(x => x.Certificate)
            .HasForeignKey(x => x.OwnerId);
    }
}
