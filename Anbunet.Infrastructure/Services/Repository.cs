using Anbunet.Domain.Abstractions;
using Anbunet.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Anbunet.Infrastructure.Services;

public abstract class Repository<TEntity>(AppDbContext dbContext) : IRepository<TEntity> where TEntity : Entity
{
    protected AppDbContext DbContext = dbContext;

    public void Add(TEntity entity) => DbContext.Add(entity);

    public Task<List<TEntity>> GetAllAsync() => DbContext
        .Set<TEntity>()
        .AsNoTracking()
        .ToListAsync();

    public Task<TEntity?> GetByIdAsync(long id) => DbContext
        .Set<TEntity>()
        .AsNoTracking()
        .FirstOrDefaultAsync(entity => entity.Id == id);
    public Task<TEntity?> GetByIdAsyncAndTracking(long id) => DbContext
        .Set<TEntity>()
        .AsQueryable()
        .FirstOrDefaultAsync(entity => entity.Id == id);

    public void Remove(TEntity entity) => DbContext
        .Set<TEntity>()
        .Remove(entity);

    public void Update(TEntity entity) => DbContext
        .Set<TEntity>()
        .Update(entity);
}