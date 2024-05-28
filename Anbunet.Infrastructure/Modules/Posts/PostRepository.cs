using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Infrastructure.DbContexts;
using Anbunet.Infrastructure.Services;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace Anbunet.Infrastructure.Modules.Posts;

public class PostRepository(AppDbContext dbContext) : Repository<Post>(dbContext), IPostRepository
{
    public Task<Post?> GetByIdWithInclude(long id, bool includeUser = false, bool includeComments = false, bool includeLikes = false)
    {
        var query = DbContext.Posts.AsNoTracking();

        if (includeUser) query = query.Include(post => post.User);
        if (includeLikes) query = query.Include(post => post.Comments);
        if (includeComments) query = query.Include(post => post.Likes); 

        return query.FirstOrDefaultAsync(post => post.Id == id);
    }
    
    public Task<Post?> GetByIdWithIncludeAndTracking(long id, bool includeUser = false, bool includeComments = false, bool includeLikes = false)
    {
        var query = DbContext.Posts.AsQueryable();

        if (includeUser) query = query.Include(post => post.User);
        if (includeLikes) query = query.Include(post => post.Likes);
        if (includeComments) query = query.Include(post => post.Comments);

        return query.FirstOrDefaultAsync(post => post.Id == id);
    }

    public Task<List<Post>> GetPostsByUserIdWithInclude(long userId, bool includeUser = false, bool includeComments = false, bool includeLikes = false)
    {
        var query = DbContext.Posts.AsNoTracking();

        if (includeUser) query = query.Include(post => post.User);
        if (includeLikes) query = query.Include(post => post.Comments);
        if (includeComments) query = query.Include(post => post.Likes);

        return query
            .Where(post => post.UserId == userId)
            .ToListAsync();
    }

    public async Task<List<Post>?> GetPostsByPaginationWithInclude(int page, int quantity, bool includeComments, bool includeLikes, bool includeUser)
    {
        var query = DbContext.Posts.AsQueryable();

        if (includeUser) query = query.Include(post => post.User);
        if (includeComments) query = query.Include(post => post.Comments);
        if (includeLikes) query = query.Include(post => post.Likes);

        query = query.Skip((page - 1) * quantity).Take(quantity);

        return await query.ToListAsync();
    }
    public async Task<List<Post>> GetPostsByUserIdsWithInclude(int page, int quantity, List<long> userIds, bool includeUser = false, bool includeComments = false, bool includeLikes = false)
    {
        var query = DbContext.Posts.AsQueryable();

        if (includeUser) query = query.Include(post => post.User);
        if (includeLikes) query = query.Include(post => post.Likes);
        if (includeComments) query = query.Include(post => post.Comments);

        query =query.Where(post => userIds.Contains(post.UserId));

        query = query.Skip((page - 1) * quantity).Take(quantity);

        return await query.ToListAsync();
    }
}

