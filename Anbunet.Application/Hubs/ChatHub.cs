﻿using Anbunet.Application.Contracts.Chats;
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
    public Task Contacts(List<ContactResponse> chats);
    public Task Chat(ChatResponse chat);
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
    public async Task JoinChat()
    {
        var userId = long.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

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

        await GetContactsAsync();

    }

    public async Task SendMessage(long chatId, string message)
    {
        var userCurrentId = long.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var userCurrent = await userRepository.GetByIdWithIncludeAndTrackingAsync(userCurrentId, includeChats: true);

        var chat = await chatRepository.GetByIdWithIncludeAndTrackingAsync(chatId, includeUsers: true, includeMessage: true);

        Message resultMessage = new Message() { };

        resultMessage.SenderId = userCurrentId;
        if (chat.Users.FirstOrDefault().Id == userCurrentId)
        {
            resultMessage.RecipientId = chat.Users.LastOrDefault().Id;

        }
        else
        {
            resultMessage.RecipientId = chat.Users.FirstOrDefault().Id;
        }

        resultMessage.DateTime = DateTime.UtcNow;
        resultMessage.Text = message;
        resultMessage.ChatId = chatId;


        chat.Messages.Add(resultMessage);
        await unitOfWork.SaveChangesAsync();
        await GetChat(chatId);

    }

    public async Task GetChat(long chatId)
    {
        var userCurrentId = long.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var chat = await chatRepository.GetByIdWithIncludeAndTrackingAsync(chatId, includeUsers: true, includeMessage: true);

        ChatResponse resultChat = new ChatResponse() { };
        resultChat.Messages = new List<MessageInfoResponse>();

        if (chat.Users.FirstOrDefault().Id == userCurrentId)
        {
            resultChat.Login = chat.Users.LastOrDefault().Login;
        }
        else
        {
            resultChat.Login = chat.Users.FirstOrDefault().Login;
        }

        resultChat.ChatId = chatId;

        foreach (var item in chat.Messages)
        {
            MessageInfoResponse message = new MessageInfoResponse() { };

            message.Text = item.Text;
            message.DateTime = item.DateTime;

            var user = await userRepository.GetByIdAsync(item.SenderId);

            message.User = mapper.Map<UserChatResponse>(user);

            resultChat.Messages.Add(message);
        }

        await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());



        await Clients
          .Groups(chatId.ToString())
          .Chat(resultChat);
    }

    public async Task GetContactsAsync()
    {
        var userId = long.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var user = await userRepository.GetByIdWithIncludeAndTrackingAsync(userId, includeChats: true);

        var chats = user.Chats.ToList();

        List<ContactResponse> resultChats = new List<ContactResponse>() { };

        foreach (var chat in chats)
        {
            var item = await chatRepository.GetByIdWithIncludeAndTrackingAsync(chat.Id, includeMessage: true, includeUsers: true);

            ContactResponse resultChat = new ContactResponse() { };
            if (resultChat.LastMessage != null)
            {
                resultChat.LastMessage = item.Messages.LastOrDefault().Text;
                resultChat.LastMessageDate = item.Messages.LastOrDefault().DateTime;
            }
                resultChat.ChatId = chat.Id;

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
                  .Contacts([]);
        }

        await Clients
                  .Caller
                  .Contacts(resultChats);

    }

}