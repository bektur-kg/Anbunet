using Anbunet.Domain.Modules.Chats;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Domain.Modules.Users;
using Anbunet.Infrastructure.DbContexts;
using Anbunet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Anbunet.Infrastructure.Modules.Chats;

public class ChatRepository(AppDbContext dbContext) : Repository<Chat>(dbContext), IChatRepository
{
    public Task<Chat?> GetByIdWithIncludeAndTrackingAsync(long chatId, bool includeUsers=false, bool includeMessage=false)
    {
        var query = DbContext.Chats.AsQueryable();
        if (includeUsers) query = query.Include(chat => chat.Users);
        if (includeMessage) query = query.Include(chat => chat.Messages);

        return query.FirstOrDefaultAsync(chat => chat.Id == chatId);
    }
}
