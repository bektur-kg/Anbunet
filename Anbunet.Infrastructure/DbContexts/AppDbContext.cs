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
    public DbSet<Story> Stories => Set<Story>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<User>()
            .HasMany(u => u.Posts)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Likes)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.UserId);

        modelBuilder.Entity<Post>()
            .HasMany(p => p.Comments)
            .WithOne(c => c.Post)
            .HasForeignKey(c => c.PostId);

        modelBuilder.Entity<Post>()
            .HasMany(p => p.Likes)
            .WithOne(l => l.Post)
            .HasForeignKey(l => l.PostId);

        //done
        modelBuilder.Entity<User>()
            .HasMany(u => u.Stories)
            .WithOne(s => s.User)
            .HasForeignKey(s => s.UserId);
    }
}

