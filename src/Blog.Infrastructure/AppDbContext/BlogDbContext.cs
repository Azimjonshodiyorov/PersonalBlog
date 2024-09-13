using Blog.Core.Entities;
using Blog.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Blog.Infrastructure.AppDbContext
{
    public sealed class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PetProject> PetProjects { get; set; }
        public DbSet<PetProjectFile> PetProjectFiles { get; set; }
        public DbSet<PostFile> PostFiles { get; set; }
        public DbSet<CertificateFile> CertificateFiles { get; set; }
        public DbSet<FileCv> FileCvs { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public BlogDbContext([NotNull]DbContextOptions<BlogDbContext> options) : base(options) {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PetProjectConfiguration());
            modelBuilder.ApplyConfiguration(new CertificateConfiguration());
        }
    }
}
