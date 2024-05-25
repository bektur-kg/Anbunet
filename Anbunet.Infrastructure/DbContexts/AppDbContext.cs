using Anbunet.Domain.Modules.Actuals;
using Anbunet.Domain.Modules.Chats;
using Anbunet.Domain.Modules.Comments;
using Anbunet.Domain.Modules.Likes;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Domain.Modules.Stories;
using Anbunet.Domain.Modules.Users;
using Azure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Anbunet.Infrastructure.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Like> Likes => Set<Like>();
    public DbSet<Actual> Actuals => Set<Actual>();
    public DbSet<Story> Stories => Set<Story>();
    public DbSet<PrivateMessage> PrivateMessages => Set<PrivateMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

