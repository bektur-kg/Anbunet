namespace Anbunet.Domain.Modules.Users;

public interface IUserRepository : IRepository<User>
{
    /// <summary>
    /// Asynchronously retrieves a user by their login.
    /// </summary>
    /// <param name="login">The login of the user to retrieve.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains the user if found; 
    /// otherwise, <c>null</c>.
    /// </returns>
    Task<User?> GetByLoginAsync(string login);

    /// <summary>
    /// Asynchronously retrieves a list of users with logins similar to the specified login.
    /// </summary>
    /// <param name="login">The login to match users against.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains a list of users 
    /// with similar logins.
    /// </returns>
    Task<List<User>> GetUsersByLoginAsync(string login);

    /// <summary>
    /// Asynchronously retrieves a user by their identifier, optionally including related posts, 
    /// followers, followings, likes, comments, actuals, and stories data.
    /// </summary>
    /// <param name="userId">The identifier of the user to retrieve.</param>
    /// <param name="includePosts">Whether to include related posts data.</param>
    /// <param name="includeFollowers">Whether to include related followers data.</param>
    /// <param name="includeFollowings">Whether to include related followings data.</param>
    /// <param name="includeLikes">Whether to include related likes data.</param>
    /// <param name="includeComments">Whether to include related comments data.</param>
    /// <param name="includeActuals">Whether to include related actuals data.</param>
    /// <param name="includeStories">Whether to include related stories data.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains the user if found; 
    /// otherwise, <c>null</c>.
    /// </returns>
    Task<User?> GetByIdWithIncludeAndTrackingAsync(
        long userId,
        bool includePosts = false,
        bool includeFollowers = false,
        bool includeFollowings = false,
        bool includeLikes = false,
        bool includeComments = false,
        bool includeActuals = false,
        bool includeStories = false,
        bool includeChats = false);

    /// <summary>
    /// Retrieves a user by their ID with optional includes for related data.
    /// </summary>
    /// <param name="userId">The ID of the user to retrieve.</param>
    /// <param name="includePosts">Include the user's posts if true.</param>
    /// <param name="includeFollowers">Include the user's followers if true.</param>
    /// <param name="includeFollowings">Include the user's followings if true.</param>
    /// <param name="includeLikes">Include the user's likes if true.</param>
    /// <param name="includeComments">Include the user's comments if true.</param>
    /// <param name="includeActuals">Include the user's actuals if true.</param>
    /// <param name="includeStories">Include the user's stories if true.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains the user if found,
    /// otherwise null.
    /// </returns>
    Task<User?> GetByIdWithIncludeAsync(
        long userId,
        bool includePosts = false,
        bool includeFollowers = false,
        bool includeFollowings = false,
        bool includeLikes = false,
        bool includeComments = false,
        bool includeActuals = false,
        bool includeStories = false,
        bool includeChats = false);

    /// <summary>
    /// Retrieves a list of IDs of the users that the specified user is following.
    /// </summary>
    /// <param name="userId">The ID of the user whose followings are to be retrieved.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains a list of user IDs
    /// that the specified user is following.
    /// </returns>
    Task<List<long>> GetFollowingsIdsAsync(long userId);
}