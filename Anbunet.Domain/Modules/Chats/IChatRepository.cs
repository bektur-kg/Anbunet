using Anbunet.Domain.Abstractions;

namespace Anbunet.Domain.Modules.Chats;

public interface IChatRepository : IRepository<PrivateMessage>
{
    Task<PrivateMessage?> GetPrivateChatByUsersAsync(string userId1, string userId2);
}
