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
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains the post if found;
    /// otherwise, <c>null</c>.
    /// </returns>
    Task<Post?> GetByIdWithIncludeAsync(
        long id, 
        bool includeUser = false, 
        bool includeComments = false, 
        bool includeLikes = false);

    /// <summary>
    /// Asynchronously retrieves a post by its identifier with tracking, optionally including related user, comments, and likes data.
    /// </summary>
    /// <param name="id">The identifier of the post to retrieve.</param>
    /// <param name="includeUser">Whether to include related user data.</param>
    /// <param name="includeComments">Whether to include related comments data.</param>
    /// <param name="includeLikes">Whether to include related likes data.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains the post if found;
    /// otherwise, <c>null</c>.
    /// </returns>
    Task<Post?> GetByIdWithIncludeAndTrackingAsync(
        long id, 
        bool includeUser = false, 
        bool includeComments = false, 
        bool includeLikes = false);

    /// <summary>
    /// Asynchronously retrieves a paginated list of posts, optionally including related comments, likes, and user data.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <param name="quantity">The number of posts per page.</param>
    /// <param name="includeComments">Whether to include related comments data.</param>
    /// <param name="includeLikes">Whether to include related likes data.</param>
    /// <param name="includeUser">Whether to include related user data.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains a list of posts for
    /// the specified page and quantity.
    /// </returns>
    Task<List<Post>?> GetPostsByPaginationWithIncludeAsync(
        int page, 
        int quantity, 
        bool includeComments, 
        bool includeLikes, 
        bool includeUser);

    /// <summary>
    /// Asynchronously retrieves all posts by a specific user identifier, optionally including related user, comments, and likes data.
    /// </summary>
    /// <param name="userId">The identifier of the user whose posts are to be retrieved.</param>
    /// <param name="includeUser">Whether to include related user data.</param>
    /// <param name="includeComments">Whether to include related comments data.</param>
    /// <param name="includeLikes">Whether to include related likes data.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains a list of posts 
    /// associated with the specified user.
    /// </returns>
    Task<List<Post>> GetPostsByUserIdWithIncludeAsync(
        long userId, 
        bool includeUser = false, 
        bool includeComments = false, 
        bool includeLikes = false);

    /// <summary>
    /// Asynchronously retrieves posts by a list of user identifiers with pagination, optionally including related user, comments, and likes data.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <param name="quantity">The number of posts per page.</param>
    /// <param name="userIds">The list of user identifiers whose posts are to be retrieved.</param>
    /// <param name="includeUser">Whether to include related user data.</param>
    /// <param name="includeComments">Whether to include related comments data.</param>
    /// <param name="includeLikes">Whether to include related likes data.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains a list of posts 
    /// for the specified page and user IDs.
    /// </returns>
    Task<List<Post>> GetPostsByUserIdsWithIncludeAsync(
        int page, 
        int quantity, 
        List<long> userIds, 
        bool includeUser = false, 
        bool includeComments = false, 
        bool includeLikes = false);
}