using Anbunet.Application.Services;
using Anbunet.Infrastructure.DbContexts;

namespace Anbunet.Infrastructure.Services;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    public Task<int> SaveChangesAsync() => dbContext.SaveChangesAsync();
}

