namespace Anbunet.Domain.Modules.Stories;

public interface IStoryRepository : IRepository<Story>
{
    /// <summary>
    /// Asynchronously retrieves recent stories associated with a specific user identifier.
    /// </summary>
    /// <param name="userId">The identifier of the user whose stories are to be retrieved.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains a list of stories 
    /// associated with the specified user.
    /// </returns>
    Task<List<Story>> GetStoriesByUserIdAsync(long userId);

    /// <summary>
    /// Asynchronously retrieves all stories associated with a specific user identifier.
    /// </summary>
    /// <param name="userId">The identifier of the user whose stories are to be retrieved.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains a list of stories 
    /// associated with the specified user.
    /// </returns>
    Task<List<Story>> GetAllCurrentUserStoriesAsync(long userId);

    /// <summary>
    /// Asynchronously retrieves a story associated with a specific story identifier.
    /// </summary>
    /// <param name="storyId">The identifier of the story to be retrieved.</param>
    /// <param name="includeUser">Whether to include related user data.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains a story 
    /// retrieved by the specified identifier.
    /// </returns>
    Task<Story?> GetByIdWithIncludeAsync(long storyId, bool includeUser = false);
}