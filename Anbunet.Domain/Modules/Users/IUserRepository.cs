using Anbunet.Domain.Abstractions;

namespace Anbunet.Domain.Modules.Users;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByLoginAsync(string login);
}
