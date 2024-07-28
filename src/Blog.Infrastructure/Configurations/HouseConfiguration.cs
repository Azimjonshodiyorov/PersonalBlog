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
    public sealed class HouseConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.ToTable("as_houses");
            builder.HasKey(house => house.Id);

            builder.Property(house => house.Id).HasColumnName("id");
            builder.Property(house => house.ObjectId).HasColumnName("objectid");
            builder.Property(house => house.ObjectGuid).HasColumnName("objectguid");

            builder.Property(house => house.Type).HasColumnName("housetype");
            builder.Property(house => house.Number).HasColumnName("housenum");

            builder.Property(house => house.FirstAdditionalType).HasColumnName("addtype1");
            builder.Property(house => house.SecondAdditionalType).HasColumnName("addtype2");

            builder.Property(house => house.FirstAdditionalNumber).HasColumnName("addnum1");
            builder.Property(house => house.SecondAdditionalNumber).HasColumnName("addnum2");
        }
    }
}
