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
        services.AddAddressDbContext(configuration);
        services.AddRepositories();
    }

    private static void AddBlogDbContext(this IServiceCollection services , IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<BlogDbContext>(option=>option.UseNpgsql(connectionString));
    }

    private static void AddAddressDbContext(this IServiceCollection services , IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("GerConnection");
        services.AddDbContext<AddressDbContext>(option => option.UseNpgsql( connectionString));
    }

    private static void AddRepositories(this IServiceCollection services)
    { 
        services.AddScoped(typeof(IRepository<>) , typeof(IRepository<>) );
        services.AddScoped<IUserRepository , UserRepository>();
        services.AddScoped<IPostRepository , PostRepository>();
        services.AddScoped<ITagRepository , TagRepository>();
        services.AddScoped<ICommunityRepository, CommunityRepository>();
        services.AddScoped<ICommentRepository , CommentRepository>();
        services.AddScoped<IAddressRepository , AddressRepository>();
    }
}