using Blog.Application.Services.TokenServices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services.AuthServices
{
    public class JwtProvider
    {
        private readonly JWTModel _jwtModel;
        private readonly JwtSecurityTokenHandler _jwtSecurityToken;

        public JwtProvider(IOptions<JWTModel> jwtModel , JwtSecurityTokenHandler jwtSecurityToken)
        {
               _jwtModel = jwtModel.Value;
               _jwtSecurityToken = jwtSecurityToken;
        }


    }
}
