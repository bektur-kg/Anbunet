using Anbunet.Domain.Modules.Chats;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Infrastructure.DbContexts;
using Anbunet.Infrastructure.Services;

namespace Anbunet.Infrastructure.Modules.Chats;

public class ChatRepository(AppDbContext dbContext) : Repository<PrivateMessage>(dbContext), IChatRepository
{
    
}
