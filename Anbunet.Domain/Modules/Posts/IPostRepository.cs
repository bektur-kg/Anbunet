using Anbunet.Domain.Abstractions;

namespace Anbunet.Domain.Modules.Posts;

public interface IPostRepository : IRepository<Post>
{
    /// <summary>
    /// Asynchronously retrieves a post by its identifier, optionally including related user, comments, and likes data.
    /// </summary>
    /// <param name="id">The identifier of the post to retrieve.</param>
    /// <param name="includeUser">Whether to include related user data.</param>
    /// <param name="includeComments">Whether to include related comments data.</param>
    /// <param name="includeLikes">Whether to include related likes data.</param>
    /// <returns>The task result contains the post if found; otherwise, <c>null</c>.</returns>
    Task<Post?> GetByIdWithInclude(long id, bool includeUser = false, bool includeComments = false, bool includeLikes = false);

    /// <summary>
    /// Asynchronously retrieves a post by its identifier with tracking, optionally including related user, comments, and likes data.
    /// </summary>
    /// <param name="id">The identifier of the post to retrieve.</param>
    /// <param name="includeUser">Whether to include related user data.</param>
    /// <param name="includeComments">Whether to include related comments data.</param>
    /// <param name="includ  eLikes">Whether to include related likes data.</param>
    /// <returns>The task result contains the post if found; otherwise, <c>null</c>.</returns>
    Task<Post?> GetByIdWithIncludeAndTracking(long id, bool includeUser = false, bool includeComments = false, bool includeLikes = false);

    /// <summary>
    /// Asynchronously retrieves a paginated list of posts, optionally including related comments, likes, and user data.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <param name="quantity">The number of posts per page.</param>
    /// <param name="includeComments">Whether to include related comments data.</param>
    /// <param name="includeLikes">Whether to include related likes data.</param>
    /// <param name="includeUser">Whether to include related user data.</param>
    /// <returns>The task result contains a list of posts for the specified page and quantity.</returns>
    Task<List<Post>?> GetPostsByPaginationWithInclude(int page, int quantity, bool includeComments, bool includeLikes, bool includeUser);

    /// <summary>
    /// Asynchronously retrieves all posts by a specific user identifier, optionally including related user, comments, and likes data.
    /// </summary>
    /// <param name="userId">The identifier of the user whose posts to retrieve.</param>
    /// <param name="includeUser">Whether to include related user data.</param>
    /// <param name="includeComments">Whether to include related comments data.</param>
    /// <param name="includeLikes">Whether to include related likes data.</param>
    /// <returns>The task result contains a list of posts associated with the specified user.</returns>
    Task<List<Post>> GetPostsByUserIdWithInclude(long userId, bool includeUser = false, bool includeComments = false, bool includeLikes = false);

    Task<List<Post>> GetPostsByUserIdsWithInclude(int page, int quantity, List<long> userIds, bool includeUser = false, bool includeComments = false, bool includeLikes = false);
}