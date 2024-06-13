using Anbunet.Application.Contracts.Chats;
using Anbunet.Application.Features.Chats.GetChats;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Chats;
using Anbunet.Domain.Modules.Users;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Net.Http;
using System.Security.Claims;

namespace Anbunet.Application.Hubs;

public interface IChatClient
{
    public Task SendMessageUser(string userName, string message);
    public Task GetChats(List<ChatResponse> chats);
}

public class ChatHub(
    IHttpContextAccessor _httpContextAccessor,
    IChatRepository chatRepository,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
    ) : Hub<IChatClient>
{
    private readonly HttpContext httpContext = _httpContextAccessor.HttpContext;
    public async Task JoinChat(string currenUserId)
    {
        var userId = long.Parse(currenUserId);

        var user = await userRepository.GetByIdWithIncludeAndTrackingAsync(userId, includeChats: true);

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

        await GetChatsByUserId(currenUserId);

    }
    public async Task GetChatsByUserId(string currentUserId)
    {
        if (currentUserId == null) return ;

        var userId = long.Parse(currentUserId);

        var user = await userRepository.GetByIdWithIncludeAndTrackingAsync(userId, includeChats: true);

        var chats = user.Chats.ToList();

        List<ChatResponse> resultChats = new List<ChatResponse>() { };

        foreach (var chat in chats)
        {
            var item = await chatRepository.GetByIdWithIncludeAndTrackingAsync(chat.Id, includeMessage: true, includeUsers: true);

            var resultChat = mapper.Map<ChatResponse>(item);
            if (item.Users.FirstOrDefault().Id == userId)
            {
                resultChat.User = mapper.Map<UserChatResponse>(item.Users.LastOrDefault());
            }
            else
            {
                resultChat.User = mapper.Map<UserChatResponse>(item.Users.FirstOrDefault());
            }
            resultChats.Add(resultChat);
        }
        if (resultChats.Count == 0)
        {
            await Clients
                  .Caller
                  .GetChats([]);
        }

        await Clients
                  .Caller
                  .GetChats(resultChats);

    }

}