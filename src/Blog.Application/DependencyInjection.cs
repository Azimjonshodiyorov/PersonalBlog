using System.Reflection;
using System.Text;
using Blog.Application.DTOs.Account.Mapping;
using Blog.Application.Services.AuthServices;
using Blog.Application.Services.AuthServices.Interfaces;
using Blog.Application.Services.CertificateServices;
using Blog.Application.Services.CertificateServices.Interfaces;
using Blog.Application.Services.FileServices;
using Blog.Application.Services.FileServices.Interfaces;
using Blog.Application.Services.PetProjectServices;
using Blog.Application.Services.PetProjectServices.Interfaces;
using Blog.Application.Services.PostServices;
using Blog.Application.Services.PostServices.Interfaces;
using Blog.Application.Services.TokenServices;
using Blog.Application.Services.TokenServices.Interfaces;
using Blog.Application.Services.UserServices;
using Blog.Application.Services.UserServices.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.Configure<JwtSettings>(configuration.GetSection("JWT"));
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICertificateService, CertificateService>();
        services.AddScoped<IFileCvService,FileCvService>();
        services.AddScoped<IPetProjectService, PetProjectService>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            var jwtSettings = configuration.GetSection("JWT").Get<JwtSettings>();
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
            };
        });
        services.AddControllers();
    }
    
    
}