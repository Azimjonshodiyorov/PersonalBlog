using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configurations
{
    public sealed class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.UserId);

            builder
                .HasMany(x=>x.PostFiles)
                .WithOne(x=>x.Post)
                .HasForeignKey(x=>x.OwnerId);
        }
    }
}
