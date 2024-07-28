using Blog.Core.Entities.Address.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities.Address
{
    public sealed class House
    {
        public long Id { get; set; }
        public long ObjectId { get; set; }
        public Guid ObjectGuid { get; set; }

        public string? Number { get; set; }
        public HouseType? Type { get; set; }

        public string? FirstAdditionalNumber { get; set; }
        public string? SecondAdditionalNumber { get; set; }

        public AdditionalPartHouseType? FirstAdditionalType { get; set; }
        public AdditionalPartHouseType? SecondAdditionalType { get; set; }
    }
}
