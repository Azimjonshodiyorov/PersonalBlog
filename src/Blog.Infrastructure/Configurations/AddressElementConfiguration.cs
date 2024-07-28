using Blog.Core.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Configurations
{
    public sealed class AddressElementConfiguration : IEntityTypeConfiguration<AddressElement>
    {
        public void Configure(EntityTypeBuilder<AddressElement> builder)
        {
            builder.ToTable("as_addr_obj");
            builder.HasKey(address => address.Id);

            builder.Property(address => address.Id).HasColumnName("id");
            builder.Property(address => address.ObjectId).HasColumnName("objectid");
            builder.Property(address => address.ObjectGuid).HasColumnName("objectguid");

            builder.Property(address => address.Name).HasColumnName("name");
            builder.Property(address => address.TypeName).HasColumnName("typename");

            builder.Property(address => address.Level).HasColumnName("level");
        }
    }
}
