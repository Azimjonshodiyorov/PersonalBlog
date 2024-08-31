using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasMany(x => x.PetProjects)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
        builder
            .HasMany(x => x.Certificates)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
        builder
            .HasMany(x => x.FileCvs)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
        
    }
}