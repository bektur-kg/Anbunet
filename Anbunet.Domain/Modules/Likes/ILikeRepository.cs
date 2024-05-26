using Anbunet.Domain.Abstractions;

namespace Anbunet.Domain.Modules.Likes;

public interface ILikeRepository : IRepository<Like>
{
    Task<List<Like>> GetPostLikesWithInclude(long postId, bool includeUser = false);
}
