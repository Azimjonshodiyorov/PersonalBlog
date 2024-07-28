using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.DTOs.Tokens
{
    public record RefreshTokenRequest(string refreshToken);
}
