using Anbunet.Domain.Modules.Chats;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Infrastructure.DbContexts;
using Anbunet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Anbunet.Infrastructure.Modules.Chats;

public class ChatRepository(AppDbContext dbContext) : Repository<PrivateMessage>(dbContext), IChatRepository
{
    public async Task<PrivateMessage?> GetPrivateChatByUsersAsync(string userId1, string userId2)
    {
        return await DbContext.PrivateMessages
            .FirstOrDefaultAsync(pm => pm.UserIds.Contains(userId1) && pm.UserIds.Contains(userId2));
    }
}
