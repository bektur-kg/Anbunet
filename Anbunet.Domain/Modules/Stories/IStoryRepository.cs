using Anbunet.Domain.Abstractions;

namespace Anbunet.Domain.Modules.Stories;

public interface IStoryRepository : IRepository<Story>
{
    Task<List<Story>> GetStoriesByUserIdAsync(long userId);
}
