using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Configurations
{
    public sealed class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasMany(x => x.Tags)
                .WithMany(x => x.Posts);

            builder
           .HasOne(post => post.User)
           .WithMany(user => user.Posts)
           .HasForeignKey(post => post.UserId);

            builder
                .HasMany(post => post.FavoriteByUsers)
                .WithMany(user => user.FavoritePosts)
                .UsingEntity<FavoritePost>(
                    l => l.HasOne<User>().WithMany().HasForeignKey(e => e.UserId),
                    r => r.HasOne<Post>().WithMany().HasForeignKey(e => e.PostId));
        }
    }
}
