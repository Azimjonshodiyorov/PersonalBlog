using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities.Address
{
    public sealed class AddressElement
    {
        public long Id { get; set; }
        public long ObjectId { get; set; }
        public Guid ObjectGuid { get; set; }

        public required string Name { get; set; }
        public required string TypeName { get; set; }

        public required string Level { get; set; }
    }
}
