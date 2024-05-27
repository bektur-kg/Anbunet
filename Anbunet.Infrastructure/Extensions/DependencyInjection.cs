using Anbunet.Application.Services;
using Anbunet.Domain.Modules.Comments;
using Anbunet.Domain.Modules.Likes;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Domain.Modules.Stories;
using Anbunet.Domain.Modules.Users;
using Anbunet.Infrastructure.DbContexts;
using Anbunet.Infrastructure.Modules.Comments;
using Anbunet.Infrastructure.Modules.Likes;
using Anbunet.Infrastructure.Modules.Posts;
using Anbunet.Infrastructure.Modules.Stories;
using Anbunet.Infrastructure.Modules.Users;
using Anbunet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Anbunet.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AppDbContext");

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddTransient<IPasswordManager, PasswordManager>();
        services.AddTransient<IJwtProvider, JwtProvider>();
        services.AddScoped<IFileProvider, FileProvider>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ILikeRepository, LikeRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IStoryRepository, StoryRepository>();

        return services;
    }
}

