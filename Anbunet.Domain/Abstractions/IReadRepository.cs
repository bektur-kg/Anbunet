namespace Anbunet.Domain.Abstractions;

public interface IReadRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Asynchronously retrieves all entities of type <typeparamref name="TEntity"/>.
    /// </summary>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains a list of all entities.
    /// </returns>
    Task<List<TEntity>> GetAllAsync();

    /// <summary>
    /// Asynchronously retrieves an entity of type <typeparamref name="TEntity"/> by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to retrieve.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains the entity if found;
    /// otherwise, <c>null</c>.
    /// </returns>
    Task<TEntity?> GetByIdAsync(long id);

    /// <summary>
    /// Asynchronously retrieves an entity of type <typeparamref name="TEntity"/> by its identifier with tracking.
    /// </summary>
    /// <param name="id">The identifier of the entity to retrieve.</param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains the entity if found;
    /// otherwise, <c>null</c>.
    /// </returns>
    Task<TEntity?> GetByIdAsyncAndTracking(long id);
}