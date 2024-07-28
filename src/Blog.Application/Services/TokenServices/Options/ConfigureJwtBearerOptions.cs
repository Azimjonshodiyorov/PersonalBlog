using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.TokenServices.Options
{
    public sealed class ConfigureJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly JWTModel _jwtModel;

        public ConfigureJwtBearerOptions(IOptions<JWTModel> jwtModel) =>
            _jwtModel = jwtModel.Value; 
        public void Configure(string? name, JwtBearerOptions options)
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = _jwtModel.Issuer,
                ValidAudience = _jwtModel.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtModel.Key))
            };
        }

        public void Configure(JwtBearerOptions options)
        {
            Configure(options);
        }
    }
}
