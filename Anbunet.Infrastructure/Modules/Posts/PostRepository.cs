namespace Anbunet.Infrastructure.Modules.Posts;

public class PostRepository(AppDbContext dbContext) : Repository<Post>(dbContext), IPostRepository
{
    public Task<Post?> GetByIdWithIncludeAsync(long id, bool includeUser = false, bool includeComments = false, bool includeLikes = false)
    {
        var query = DbContext.Posts.AsNoTracking();

        if (includeUser) query = query.Include(post => post.User);
        if (includeLikes) query = query.Include(post => post.Comments);
        if (includeComments) query = query.Include(post => post.Likes);

        return query.FirstOrDefaultAsync(post => post.Id == id);
    }

    public Task<Post?> GetByIdWithIncludeAndTrackingAsync(long id, bool includeUser = false, bool includeComments = false, bool includeLikes = false)
    {
        var query = DbContext.Posts.AsQueryable();

        if (includeUser) query = query.Include(post => post.User);
        if (includeLikes) query = query.Include(post => post.Likes);
        if (includeComments) query = query.Include(post => post.Comments);

        return query.FirstOrDefaultAsync(post => post.Id == id);
    }

    public Task<List<Post>> GetPostsByUserIdWithIncludeAsync(long userId, bool includeUser = false, bool includeComments = false, bool includeLikes = false)
    {
        var query = DbContext.Posts.AsNoTracking();

        if (includeUser) query = query.Include(post => post.User);
        if (includeLikes) query = query.Include(post => post.Comments);
        if (includeComments) query = query.Include(post => post.Likes);

        return query
            .Where(post => post.UserId == userId)
            .ToListAsync();
    }

    public async Task<List<Post>> GetPostsByPaginationWithIncludeAsync(int page, int quantity, bool includeComments, bool includeLikes, bool includeUser)
    {
        var query = DbContext.Posts.AsQueryable();

        if (includeUser) query = query.Include(post => post.User);
        if (includeComments) query = query.Include(post => post.Comments).ThenInclude(comment => comment.User);
        if (includeLikes) query = query.Include(post => post.Likes).ThenInclude(like => like.User);

        query = query.OrderByDescending(post => post.Likes.Count);

        query = query.Skip((page - 1) * quantity).Take(quantity);

        return await query.ToListAsync();
    }

    public async Task<List<Post>> GetPostsByUserIdsWithIncludeAsync(int page, int quantity, List<long> userIds, bool includeUser = false, bool includeComments = false, bool includeLikes = false)
    {
        var query = DbContext.Posts.AsQueryable();

        if (includeUser) query = query.Include(post => post.User);
        if (includeLikes) query = query.Include(post => post.Likes).ThenInclude(like => like.User);
        if (includeComments) query = query.Include(post => post.Comments).ThenInclude(comment => comment.User);

        query = query.Where(post => userIds.Contains(post.UserId));
        query = query.OrderByDescending(post => post.CreatedDate);
        query = query.Skip((page - 1) * quantity).Take(quantity);

        return await query.ToListAsync();
    }
}