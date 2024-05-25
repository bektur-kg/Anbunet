using Anbunet.Application.Features.Chats;
using Anbunet.Application.Services;
using Anbunet.Domain.Modules.Chats;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Domain.Modules.Users;
using Anbunet.Infrastructure.DbContexts;
using Anbunet.Infrastructure.Modules.Chats;
using Anbunet.Infrastructure.Modules.Posts;
using Anbunet.Infrastructure.Modules.Users;
using Anbunet.Infrastructure.Services;
using Microsoft.AspNetCore.SignalR;
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
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();

        return services;
    }
}

