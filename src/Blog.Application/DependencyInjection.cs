﻿using Blog.Application.Services.AuthServices;
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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
    }
    
    
}