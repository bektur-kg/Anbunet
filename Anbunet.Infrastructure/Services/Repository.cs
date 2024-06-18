namespace Anbunet.Infrastructure.Services;

/// <inheritdoc cref="IRepository{TEntity}" />
public abstract class Repository<TEntity>(AppDbContext dbContext) : IRepository<TEntity> where TEntity : Entity
{
    protected AppDbContext DbContext = dbContext;

    /// <inheritdoc />
    public void Add(TEntity entity) => DbContext.Add(entity);

    /// <inheritdoc />
    public Task<List<TEntity>> GetAllAsync() => DbContext
        .Set<TEntity>()
        .AsNoTracking()
        .ToListAsync();

    /// <inheritdoc />
    public Task<TEntity?> GetByIdAsync(long id) => DbContext
        .Set<TEntity>()
        .AsNoTracking()
        .FirstOrDefaultAsync(entity => entity.Id == id);

    /// <inheritdoc />
    public Task<TEntity?> GetByIdAsyncAndTracking(long id) => DbContext
        .Set<TEntity>()
        .AsQueryable()
        .FirstOrDefaultAsync(entity => entity.Id == id);

    /// <inheritdoc />
    public void Remove(TEntity entity) => DbContext
        .Set<TEntity>()
        .Remove(entity);

    /// <inheritdoc />
    public void Update(TEntity entity) => DbContext
        .Set<TEntity>()
        .Update(entity);
}
