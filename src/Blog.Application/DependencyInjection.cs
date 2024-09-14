using System.Reflection;
using System.Text;
using Blog.Application.DTOs.Account.Mapping;
using Blog.Application.DTOs.File;
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
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Minio;

namespace Blog.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        
        // Bind JwtSettings from the configuration
        var jwtSettings = new JwtSettings();
        configuration.GetSection("JwtSettings").Bind(jwtSettings);

        // Register JwtSettings in the DI container
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.Configure<MinioSettings>(configuration.GetSection("MinioSettings"));

        services.AddSingleton(x =>
        {
            var minioSettings = x.GetRequiredService<IOptions<MinioSettings>>().Value;
            return new MinioClient()
                .WithEndpoint(minioSettings.Endpoint)
                .WithCredentials(minioSettings.AccessKey, minioSettings.SecretKey)
                .Build();
        });
        // Register services
        services.AddScoped<IPostService, PostService>();
        services.AddScoped(typeof(IMinioService<>) , typeof(MinioService<>));
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICertificateService, CertificateService>();
        services.AddScoped<IFileCvService, FileCvService>();
        services.AddScoped<IPetProjectService, PetProjectService>();
        services.AddScoped<ITokenService, TokenService>();

        // Register AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        // Configure JWT Authentication
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            // Validate JwtSettings
            if (jwtSettings == null || string.IsNullOrWhiteSpace(jwtSettings.Key))
            {
                throw new ArgumentNullException("JwtSettings.Key", "JWT Key cannot be null or empty.");
            }

            // Set up Token Validation Parameters
            options.RequireHttpsMetadata = true; // HTTPS ni talab qiladimi tekshirish
            options.SaveToken = true;
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

        // Register MVC Controllers
        services.AddControllers();
    }
}
