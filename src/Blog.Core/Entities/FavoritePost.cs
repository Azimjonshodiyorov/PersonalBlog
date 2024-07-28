using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public sealed class FavoritePost : BaseEntity
    {
        public required Guid UserId { get; set; }
        public required Guid PostId { get; set; }
    }
}
