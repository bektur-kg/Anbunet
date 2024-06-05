namespace Anbunet.Domain.Modules.Stories;

public interface IStoryRepository : IRepository<Story>
{
    /// <summary>
    /// Asynchronously retrieves all stories associated with a specific user identifier.
    /// </summary>
    /// <param name="userId">The identifier of the user whose stories to retrieve.</param>
    /// <returns>The task result contains a list of stories associated with the specified user.</returns>
    Task<List<Story>> GetStoriesByUserIdAsync(long userId);
}