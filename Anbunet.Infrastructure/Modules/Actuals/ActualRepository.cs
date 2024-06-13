namespace Anbunet.Infrastructure.Modules.Actuals;

public class ActualRepository(AppDbContext dbContext) : Repository<Actual>(dbContext), IActualRepository
{
    /// <inheritdoc/>
    public Task<List<Actual>> GetActualsByUserIdWithIncludeAsync(long id, bool includeUser = false, bool includeStories = false)
    {
        var query = DbContext.Actuals.AsNoTracking();

        if (includeUser) query = query.Include(actual => actual.User);
        if (includeStories) query = query.Include(actual => actual.Stories);

        return query.Where(actual => actual.UserId == id).ToListAsync();
    }

    /// <inheritdoc/>
    public Task<Actual?> GetByIdWithIncludeAsync(long id, bool includeUser = false, bool includeStories = false)
    {
        var query = DbContext.Actuals.AsNoTracking();

        if (includeUser) query = query.Include(actual => actual.User);
        if (includeStories) query = query.Include(actual => actual.Stories);

        return query.FirstOrDefaultAsync(actual => actual.Id == id);
    }

    /// <inheritdoc/>
    public Task<Actual?> GetByIdWithIncludeAndTrackedAsync(long id, bool includeUser = false, bool includeStories = false)
    {
        var query = DbContext.Actuals.AsQueryable();

        if (includeUser) query = query.Include(actual => actual.User);
        if (includeStories) query = query.Include(actual => actual.Stories);

        return query.FirstOrDefaultAsync(actual => actual.Id == id);
    }
}