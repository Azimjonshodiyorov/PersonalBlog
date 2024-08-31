using Blog.Infrastructure.AppDbContext;
using Blog.Infrastructure.Repositories;
using Blog.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Blog.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddBlogDbContext(configuration);
        services.AddRepositories();
    }

    private static void AddBlogDbContext(this IServiceCollection services , IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<BlogDbContext>(option=>option.UseNpgsql(connectionString));
    }

    private static void AddRepositories(this IServiceCollection services)
    { 

    }
}