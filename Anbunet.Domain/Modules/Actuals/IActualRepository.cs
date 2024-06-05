using Anbunet.Domain.Abstractions;

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
    /// <returns>The task result contains the entity if found otherwise, <c>null</c>.</returns>
    Task<Actual?> GetByIdWithInclude(long id, bool includeUser = false, bool includeStories = false);
}