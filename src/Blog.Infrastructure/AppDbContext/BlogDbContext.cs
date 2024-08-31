using Blog.Core.Entities;
using Blog.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.AppDbContext
{
    public sealed class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PetProject> PetProjects { get; set; }
        public DbSet<FileCv> FileCvs { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
