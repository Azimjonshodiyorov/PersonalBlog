using System.Reflection;
using System.Text;
using Blog.Application.DTOs.Files;
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
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

        // Bind MinioSettings
        var minioSettings = new MinioSettings();
        configuration.GetSection("MinioSettings").Bind(minioSettings);

        // Register MinioClient
        services.AddSingleton<MinioClient>(sp =>
        {
            return (MinioClient)new MinioClient()
                .WithEndpoint(minioSettings.Endpoint, 9000)
                .WithCredentials(minioSettings.AccessKey, minioSettings.SecretKey)
                .WithSSL(false)
                .Build();
        });

        // Register JwtSettings and MinioSettings in the DI container
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.Configure<MinioSettings>(configuration.GetSection("MinioSettings"));

        // Register services
        services.AddScoped<IPostService, PostService>();
        services.AddScoped(typeof(IMinioService<>), typeof(MinioService<>));
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICertificateService, CertificateService>();
        services.AddScoped<IFileCvService, FileCvService>();
        services.AddScoped<IPetProjectService, PetProjectService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        services.Configure<FormOptions>(options =>
        {
            options.MultipartBodyLengthLimit = 1073741824; // Bu 1 GB ga teng (siz kerakli hajmni qo'yishingiz mumkin)
        });
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
                ClockSkew = TimeSpan.Zero,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
            };
        });

        // Register MVC Controllers
        services.AddControllers();
    }

}
