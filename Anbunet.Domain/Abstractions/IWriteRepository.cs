namespace Anbunet.Domain.Abstractions;

public interface IWriteRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Adds a new entity of type <typeparamref name="TEntity"/> to the database.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    void AddAsync(TEntity entity);

    /// <summary>
    /// Removes an existing entity of type <typeparamref name="TEntity"/> from the database.
    /// </summary>
    /// <param name="entity">The entity to remove.</param>
    void Remove(TEntity entity);

    /// <summary>
    /// Updates an existing entity of type <typeparamref name="TEntity"/> in the database.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    void Update(TEntity entity);
}