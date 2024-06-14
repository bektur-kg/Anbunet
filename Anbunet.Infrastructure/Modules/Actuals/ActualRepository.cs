using Anbunet.Domain.Modules.Actuals;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Infrastructure.DbContexts;
using Anbunet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Anbunet.Infrastructure.Modules.Actuals;

public class ActualRepository(AppDbContext dbContext) : Repository<Actual>(dbContext), IActualRepository
{
    public Task<List<Actual>> GetActualsByUserIdWithInclude(long id, bool includeUser = false, bool includeStories = false)
    {
        var query = DbContext.Actuals.AsNoTracking();

        if (includeUser) query = query.Include(actual => actual.User);
        if (includeStories) query = query.Include(actual => actual.Stories);

        return query.Where(actual => actual.UserId == id).ToListAsync();
    }

    public Task<Actual?> GetByIdWithInclude(long id, bool includeUser = false, bool includeStories = false)
    {
        var query = DbContext.Actuals.AsNoTracking();

        if (includeUser) query = query.Include(actual => actual.User);
        if (includeStories) query = query.Include(actual => actual.Stories);

        return query.FirstOrDefaultAsync(actual => actual.Id == id);
    }

    public Task<Actual?> GetByIdWithIncludeAndTracked(long id, bool includeUser = false, bool includeStories = false)
    {
        var query = DbContext.Actuals.AsQueryable();

        if (includeUser) query = query.Include(actual => actual.User);
        if (includeStories) query = query.Include(actual => actual.Stories);

        return query.FirstOrDefaultAsync(actual => actual.Id == id);
    }
}