using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;

namespace Anbunet.Domain.Modules.Comments;

public interface ICommentRepository : IRepository<Comment>
{
    Task<Comment?> GetByIdWithInclude(long id, bool includeUser = false, bool includePost = false);

    Task<List<Comment>> GetAllByPostIdAsync(long postId);
}