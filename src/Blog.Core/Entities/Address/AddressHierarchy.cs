using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities.Address
{
    public sealed class AddressHierarchy
    {

        public long Id { get; set; }
        public long ObjectId { get; set; }
        public long ParentObjectId { get; set; }
        public required string Path { get; set; }
    }
}
