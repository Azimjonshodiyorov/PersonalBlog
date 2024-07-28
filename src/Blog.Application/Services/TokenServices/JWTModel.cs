using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.TokenServices
{
    public sealed class JWTModel 
    {
        public required string Key { get; set; }
        public required string RefreshKey { get; set; }

        public required string Issuer { get; set; }
        public required string Audience { get; set; }

        public required double LifetimeInMinutes { get; set; }
        public required double RefreshLifetimeInDays { get; set; }
    }
}
