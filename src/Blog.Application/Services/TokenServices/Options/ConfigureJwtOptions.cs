using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.TokenServices.Options
{
    public sealed class ConfigureJwtOptions : IConfigureOptions<JWTModel>
    {
        private const string SectionName = "JWTOptions";
        private readonly IConfiguration _configuration;

        public ConfigureJwtOptions(IConfiguration configuration) =>
            _configuration = configuration;

        public void Configure(JWTModel options)
        {
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}
