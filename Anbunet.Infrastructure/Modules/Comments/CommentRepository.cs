using Anbunet.Domain.Modules.Comments;
using Anbunet.Infrastructure.DbContexts;
using Anbunet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Anbunet.Infrastructure.Modules.Comments;

public class CommentRepository(AppDbContext dbContext) : Repository<Comment>(dbContext), ICommentRepository
{
    public Task<List<Comment>> GetPostCommentsWithInclude(long postId, bool includeUser = false)
    {
        var query = DbContext.Comments.AsNoTracking();

        if (includeUser) query = query.Include(comment => comment.User);

        return query
            .Where(comment => comment.PostId == postId)
            .ToListAsync();
    }
}

