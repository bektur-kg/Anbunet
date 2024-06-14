namespace Anbunet.Infrastructure.Modules.Comments;

public class CommentRepository(AppDbContext dbContext) : Repository<Comment>(dbContext), ICommentRepository
{
    public Task<List<Comment>> GetAllByPostIdAsync(long postId)
    {
        var query = DbContext.Comments.AsNoTracking();

        query.Include(x => x.User);

        return query.Where(c => c.PostId == postId).ToListAsync();
    }

    public Task<Comment?> GetByIdWithIncludeAsync(long id, bool includeUser = false, bool includePost = false)
    {
        var query = DbContext.Comments.AsQueryable();

        if (includeUser) query = query.Include(comment => comment.User);
        if (includePost) query = query.Include(comment => comment.Post);

        return query.FirstOrDefaultAsync(comment => comment.Id == id);
    }

    public Task<List<Comment>> GetPostCommentsWithIncludeAsync(long postId, bool includeUser = false)
    {
        var query = DbContext.Comments.AsNoTracking();

        if (includeUser) query = query.Include(comment => comment.User);

        return query
            .Where(comment => comment.PostId == postId)
            .ToListAsync();
    }
}