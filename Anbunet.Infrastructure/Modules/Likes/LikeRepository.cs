namespace Anbunet.Infrastructure.Modules.Likes;

public class LikeRepository(AppDbContext dbContext) : Repository<Like>(dbContext), ILikeRepository
{
    public Task<List<Like>> GetPostLikesWithIncludeAsync(long postId, bool includeUser = false)
    {
        var query = DbContext.Likes.AsNoTracking();

        if (includeUser) query = query.Include(like => like.User);

        return query
            .Where(like => like.PostId == postId)
            .ToListAsync();
    }
}

