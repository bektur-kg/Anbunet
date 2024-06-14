namespace Anbunet.Domain.Modules.Actuals;

public interface IActualRepository : IRepository<Actual>
{
    /// <summary>
    /// Asynchronously retrieves an entity of type <typeparamref name="Actual"/> by its identifier,
    /// optionally including related user and stories data.
    /// </summary>
    /// <param name="id">The identifier of the entity to retrieve.</param>
    /// <param name="includeUser">Whether to include related user data.</param>
    /// <param name="includeStories">Whether to include related stories data.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains the entity if found;
    /// otherwise, <c>null</c>.
    /// </returns>
    Task<Actual?> GetByIdWithIncludeAsync(
        long id, 
        bool includeUser = false, 
        bool includeStories = false);

    /// <summary>
    /// Asynchronously retrieves a list of entities of type <typeparamref name="Actual"/> by a specific user identifier,
    /// optionally including related user and stories data.
    /// </summary>
    /// <param name="id">The identifier of the user whose entities are to be retrieved.</param>
    /// <param name="includeUser">Whether to include related user data.</param>
    /// <param name="includeStories">Whether to include related stories data.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains a list of entities
    /// associated with the specified user.
    /// </returns>
    Task<List<Actual>> GetActualsByUserIdWithIncludeAsync(
        long id, 
        bool includeUser = false, 
        bool includeStories = false);

    /// <summary>
    /// Asynchronously retrieves an entity of type <typeparamref name="Actual"/> by its identifier with tracking,
    /// optionally including related user and stories data.
    /// </summary>
    /// <param name="id">The identifier of the entity to retrieve.</param>
    /// <param name="includeUser">Whether to include related user data.</param>
    /// <param name="includeStories">Whether to include related stories data.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains the entity if found;
    /// otherwise, <c>null</c>.
    /// </returns>
    Task<Actual?> GetByIdWithIncludeAndTrackedAsync(
        long id, 
        bool includeUser = false, 
        bool includeStories = false);

}