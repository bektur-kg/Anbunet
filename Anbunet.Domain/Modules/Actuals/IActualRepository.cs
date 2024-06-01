using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;

namespace Anbunet.Domain.Modules.Actuals;

public interface IActualRepository : IRepository<Actual>
{
    Task<Actual?> GetByIdWithInclude(long id, bool includeUser = false, bool includeStories = false);
}