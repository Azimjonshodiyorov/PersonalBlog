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
    public sealed class CommunityRequestConfiguration : IEntityTypeConfiguration<CommunityRequest>
    {
        public void Configure(EntityTypeBuilder<CommunityRequest> builder)
        {
            builder.HasKey(request => new { request.UserId, request.CommunityId });
        }
    }
}
