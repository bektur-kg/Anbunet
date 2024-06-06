namespace Anbunet.Domain.Abstractions;

public interface IRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>
    where TEntity : Entity;