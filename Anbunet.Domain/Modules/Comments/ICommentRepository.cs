using Anbunet.Domain.Abstractions;

namespace Anbunet.Domain.Modules.Comments;

public interface ICommentRepository : IRepository<Comment>
{
    Task<List<Comment>> GetPostCommentsWithInclude(long postId, bool includeUser = false);
}
