using Anbunet.Domain.Modules.Posts;
using Anbunet.Domain.Modules.Users;
using Anbunet.Infrastructure.DbContexts;
using Anbunet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Anbunet.Infrastructure.Modules.Users;

public class UserRepository(AppDbContext dbContext) : Repository<User>(dbContext), IUserRepository
{
    public Task<User?> GetByIdWithIncludeAsync(long userId, bool includePosts = false, bool includeFollowers = false, bool includeFollowings = false, 
        bool includeLikes = false, bool includeComments = false, bool includeActuals = false, bool includeStories = false)
    {
        var query = DbContext.Users.AsNoTracking();

        if (includePosts) query = query.Include(user => user.Posts);
        if (includeFollowers) query = query.Include(user => user.Followers);
        if (includeFollowings) query = query.Include(user => user.Followings);
        if (includeComments) query = query.Include(user => user.Comments);
        if (includeActuals) query = query.Include(user => user.Actuals);
        if (includeStories) query = query.Include(user => user.Stories.Where(story => story.ExpiryDate > DateTime.UtcNow));

        return query.FirstOrDefaultAsync(user => user.Id == userId);
    }

    public Task<User?> GetByLoginAsync(string login)
    {
        return DbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Login == login);
    }

    public Task<List<long>> GetFollowingsIds(long userId)
    {
        return DbContext.Users
            .Where(user => user.Id == userId)
            .SelectMany(user => user.Followings.Select(f => f.Id))
            .ToListAsync();
    }


}

