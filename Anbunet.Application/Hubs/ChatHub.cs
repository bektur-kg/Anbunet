using Anbunet.Application.Services;
using Anbunet.Domain.Modules.Chats;
using Anbunet.Domain.Modules.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

namespace Anbunet.Application.Hubs;

public interface IChatClient
{
    public Task SendMessageUser(string userName, string message);
}

public class ChatHub(
    IHttpContextAccessor _httpContextAccessor,
    IChatRepository chatRepository,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork
    ) : Hub<IChatClient>
{
    private readonly HttpContext httpContext = _httpContextAccessor.HttpContext;
    public async Task JoinChat(string currenUserId)
    {
        var userId = long.Parse(currenUserId);

        var user = await userRepository.GetByIdWithIncludeAndTrackingAsync(userId, includeChats:true);

        var chats = user.Chats.ToList();
        if (chats != null)
        {
            foreach (var chat in chats)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, chat.Id.ToString());
                await Clients
                    .Group(chat.Id.ToString())
                    .SendMessageUser("Admin", $"{user.Login} connected to chat number {chat.Id}");
            }
        }

        
    }

}