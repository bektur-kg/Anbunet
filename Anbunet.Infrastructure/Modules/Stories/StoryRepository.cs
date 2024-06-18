using Anbunet.Domain.Modules.Users;

namespace Anbunet.Infrastructure.Modules.Stories;

public class StoryRepository(AppDbContext dbContext) : Repository<Story>(dbContext), IStoryRepository
{
    public Task<List<Story>> GetAllCurrentUserStoriesAsync(long userId)
    {
        return DbContext.Stories
            .AsNoTracking()
            .Where(story => story.UserId == userId)
            .ToListAsync();
    }

    public Task<Story?> GetByIdWithIncludeAsync(long storyId, bool includeUser = false)
    {
        var query = DbContext.Stories.AsNoTracking();

        if (includeUser) query = query.Include(story => story.User);

        return query.FirstOrDefaultAsync(story => story.Id == storyId);
    }

    public Task<List<Story>> GetStoriesByUserIdAsync(long userId)
    {
        return DbContext.Stories
            .AsNoTracking()
            .Where(story => story.UserId == userId)
            .Where(story => story.ExpiryDate > DateTime.UtcNow)
            .ToListAsync();
    }
}