﻿using Anbunet.Domain.Modules.Comments;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Infrastructure.DbContexts;
using Anbunet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Anbunet.Infrastructure.Modules.Comments;

public class CommentRepository(AppDbContext dbContext) : Repository<Comment>(dbContext), ICommentRepository
{
    public Task<List<Comment>> GetAllByPostIdAsync(long postId)
    {
        var query = DbContext.Comments.AsNoTracking();

        query.Include(x => x.User);

        return query.Where(c => c.PostId == postId).ToListAsync();
    }

    public Task<Comment?> GetByIdWithInclude(long id, bool includeUser = false, bool includePost = false)
    {
        var query = DbContext.Comments.AsQueryable();

        if (includeUser) query = query.Include(comment => comment.User);
        if (includePost) query = query.Include(comment => comment.Post);

        return query.FirstOrDefaultAsync(comment => comment.Id == id);
    }

    public Task<List<Comment>> GetPostCommentsWithInclude(long postId, bool includeUser = false)
    {
        var query = DbContext.Comments.AsNoTracking();

        if (includeUser) query = query.Include(comment => comment.User);

        return query
            .Where(comment => comment.PostId == postId)
            .ToListAsync();
    }
}