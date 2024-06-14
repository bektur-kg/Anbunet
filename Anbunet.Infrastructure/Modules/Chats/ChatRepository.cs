namespace Anbunet.Infrastructure.Modules.Chats;

public class ChatRepository(AppDbContext dbContext) : Repository<PrivateMessage>(dbContext), IChatRepository
{
    public async Task<PrivateMessage?> GetPrivateChatByUsersAsync(string userId1, string userId2)
    {
        return await DbContext.PrivateMessages
            .FirstOrDefaultAsync(pm => pm.UserIds.Contains(userId1) && pm.UserIds.Contains(userId2));
    }
}
