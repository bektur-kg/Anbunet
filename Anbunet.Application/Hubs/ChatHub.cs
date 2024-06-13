using Anbunet.Domain.Modules.Chats;
using Microsoft.AspNetCore.SignalR;

namespace Anbunet.Application.Hubs;

public class ChatHub(
    IHttpContextAccessor _httpContextAccessor,
    IChatRepository chatRepository,
    IUnitOfWork unitOfWork
    ) : Hub
{
    public async Task Enter(string groupName)
    {
        var username = Context.UserIdentifier;
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        await Clients.All.SendAsync("Notify", $"{username} вошел в чат в группу {groupName}");
    }
    public async Task Send(string message, string groupName)
    {
        var userName = Context.UserIdentifier;
        await Clients.Group(groupName).SendAsync("Receive", message, userName);
    }
    

    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("Notify", $"Приветствуем {Context.UserIdentifier}");
        await base.OnConnectedAsync();
    }

}