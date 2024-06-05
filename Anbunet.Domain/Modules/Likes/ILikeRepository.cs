using Anbunet.Domain.Abstractions;

namespace Anbunet.Domain.Modules.Likes;

public interface ILikeRepository : IRepository<Like>
{
    /// <summary>
    /// Asynchronously retrieves all likes associated with a specific post identifier,
    /// optionally including related user data.
    /// </summary>
    /// <param name="postId">The identifier of the post.</param>
    /// <param name="includeUser">Whether to include related user data.</param>
    /// <returns>The task result contains a list of likes associated with the specified post.</returns>
    Task<List<Like>> GetPostLikesWithInclude(long postId, bool includeUser = false);
}