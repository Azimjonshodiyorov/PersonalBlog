using Blog.Core.Entities;
using Blog.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.AppDbContext
{
    public sealed class BlogDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<CommunityRequest> CommunityRequests { get; set; } = null!;

        public DbSet<Like> Likes { get; set; } = null!;
        public DbSet<FavoritePost> FavoritePosts { get; set; } = null!;
        public DbSet<Subscription> Subscriptions { get; set; } = null!;
        public DbSet<CommunityAdmin> CommunityAdmins { get; set; } = null!;

        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Community> Communities { get; set; } = null!;

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new LikeConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
            modelBuilder.ApplyConfiguration(new CommunityConfiguration());
            modelBuilder.ApplyConfiguration(new CommunityAdminConfiguration());
            modelBuilder.ApplyConfiguration(new CommunityRequestConfiguration());
        }
    }
}
