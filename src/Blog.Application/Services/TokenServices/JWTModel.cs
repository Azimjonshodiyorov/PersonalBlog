using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.TokenServices
{
    public sealed class JWTModel 
    {
        public  string Key { get; set; }
        public  string RefreshKey { get; set; }

        public  string Issuer { get; set; }
        public  string Audience { get; set; }

        public  double LifetimeInMinutes { get; set; }
        public  double RefreshLifetimeInDays { get; set; }
    }
}
