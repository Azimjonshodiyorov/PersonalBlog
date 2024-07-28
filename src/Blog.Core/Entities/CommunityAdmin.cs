using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public sealed class CommunityAdmin : BaseEntity
    {
        public required Guid UserId { get; set; }
        public required Guid CommunityId { get; set; }
    }
}
