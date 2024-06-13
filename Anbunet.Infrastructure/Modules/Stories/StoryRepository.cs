namespace Anbunet.Infrastructure.Modules.Stories;

public class StoryRepository(AppDbContext dbContext) : Repository<Story>(dbContext), IStoryRepository
{
    public Task<List<Story>> GetStoriesByUserIdAsync(long userId)
    {
        return DbContext.Stories
            .AsNoTracking()
            .Where(story => story.UserId == userId)
            .Where(story => story.ExpiryDate > DateTime.UtcNow)
            .ToListAsync();
    }
}