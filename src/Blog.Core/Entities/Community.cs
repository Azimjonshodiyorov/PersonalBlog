using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public sealed class Community : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required bool IsClosed { get; set; }

        public IList<User>? Subscribers { get; set; }
        public IList<User>? Administrators { get; set; }
        public IList<CommunityRequest>? Requests { get; set; }
    }
}
