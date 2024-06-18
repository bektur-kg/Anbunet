namespace Anbunet.Domain.Modules.Chats;

public interface IChatRepository : IRepository<Chat>
{
    Task<Chat?> GetByIdWithIncludeAndTrackingAsync(long chatId, bool includeUsers= false, bool includeMessage= false);

}
