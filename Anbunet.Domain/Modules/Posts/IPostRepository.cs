using Anbunet.Domain.Abstractions;

namespace Anbunet.Domain.Modules.Posts;

public interface IPostRepository : IRepository<Post>
{
    Task<Post?> GetByIdWithInclude(long id, bool includeUser = false, bool includeComments = false, bool includeLikes = false);
    Task<Post?> GetByIdWithIncludeAndTracking(long id, bool includeUser = false, bool includeComments = false, bool includeLikes = false);
}
