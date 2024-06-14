using Anbunet.Application.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Anbunet.Application.Features.Chats.SendMessageToUser;

public class SendMessageToUserCommandHandler(
     IHubContext<ChatHub> hubContext,
     IHttpContextAccessor httpContextAccessor
    )
    
    : ICommandHandler<SendMessageToUserCommand, Result>

{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(SendMessageToUserCommand request, CancellationToken cancellationToken)
    {
        var groupName = request.Data.PrivateChatId;
        var message = request.Data.Message;
        var userName = _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        if (string.IsNullOrEmpty(groupName))
        {
            return Result.Failure(ChatErrors.SenderNotFound);
        }

        await hubContext.Clients.Group(groupName).SendAsync("Receive", message, userName);

        return Result.Success();
    }
}