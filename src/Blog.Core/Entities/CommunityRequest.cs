using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public sealed class CommunityRequest : BaseEntity
    {
        public required Guid UserId { get; set; }

        public required Guid CommunityId { get; set; }

        public User User { get; set; }
        public Community Community { get; set; }
    }
}
