namespace Anbunet.Domain.Modules.Comments;

public interface ICommentRepository : IRepository<Comment>
{
    /// <summary>
    /// Asynchronously retrieves a comment by its identifier, optionally including related user and post data.
    /// </summary>
    /// <param name="id">The identifier of the comment to retrieve.</param>
    /// <param name="includeUser">Whether to include related user data.</param>
    /// <param name="includePost">Whether to include related post data.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains the comment if found;
    /// otherwise, <c>null</c>.
    /// </returns>
    Task<Comment?> GetByIdWithIncludeAsync(
        long id, 
        bool includeUser = false, 
        bool includePost = false);

    /// <summary>
    /// Asynchronously retrieves all comments associated with a specific post identifier.
    /// </summary>
    /// <param name="postId">The identifier of the post.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains a list of comments 
    /// associated with the specified post.
    /// </returns>
    Task<List<Comment>> GetAllByPostIdAsync(long postId);

    /// <summary>
    /// Asynchronously retrieves all comments associated with a specific post identifier, 
    /// optionally including related user data.
    /// </summary>
    /// <param name="postId">The identifier of the post.</param>
    /// <param name="includeUser">Whether to include related user data.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains a list of comments 
    /// associated with the specified post.
    /// </returns>
    Task<List<Comment>> GetPostCommentsWithIncludeAsync(
        long postId, 
        bool includeUser = false);
}