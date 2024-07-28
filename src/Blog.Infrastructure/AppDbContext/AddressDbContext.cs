using Blog.Core.Entities.Address;
using Blog.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.AppDbContext
{
    public sealed class AddressDbContext : DbContext
    {
        public DbSet<House> Houses { get; set; } = null!;
        public DbSet<AddressElement> AddressElements { get; set; } = null!;
        public DbSet<AddressHierarchy> AddressHierarchies { get; set; } = null!;

        public AddressDbContext(DbContextOptions<AddressDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new HouseConfiguration());
            modelBuilder.ApplyConfiguration(new AddressElementConfiguration());
            modelBuilder.ApplyConfiguration(new AddressHierarchyConfiguration());
        }
    }
}
