using Anbunet.Application.Services;
using Anbunet.Domain.Modules.Chats;
using Anbunet.Domain.Modules.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Security.Claims;

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