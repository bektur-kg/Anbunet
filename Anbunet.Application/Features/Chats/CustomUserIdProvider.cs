using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Anbunet.Application.Features.Chats;

public class CustomUserIdProvider : IUserIdProvider
{
    public virtual string? GetUserId(HubConnectionContext connection)
    {
        return connection.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}