using Anbunet.Application.Abstractions;
using Anbunet.Application.Features.Posts.Create;
using Anbunet.Application.Hubs;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Chats;
using Anbunet.Domain.Modules.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Anbunet.Application.Features.Chats.SendMessageToUser;

public class SendMessageToUserCommandHandler
    (HttpContext httpContext,
     IHubContext<ChatHub> hubContext
    )
    : ICommandHandler<SendMessageToUserCommand, Result>
{
    public async Task<Result> Handle(SendMessageToUserCommand request, CancellationToken cancellationToken)
    {
        // получение текущего пользователя, который отправил сообщение
        var senderId = httpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        var recipientId = request.Data.RecipientId;
        var message = request.Data.Message;

        if (string.IsNullOrEmpty(senderId))
        {
            return Result.Failure(ChatErrors.SenderNotFound);
        }

        var result = await hubContext.Clients.Users(recipientId, senderId).SendAsync("Receive", message, senderId);
        return Result.Success();
    }
}
