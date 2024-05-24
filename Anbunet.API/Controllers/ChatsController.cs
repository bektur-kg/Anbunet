using Anbunet.API.Hubs;
using Anbunet.Application.Contracts.Chats;
using Anbunet.Application.Contracts.Posts;
using Anbunet.Application.Features.Chats.SendMessageToUser;
using Anbunet.Application.Features.Posts.Create;
using Anbunet.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Anbunet.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ChatsController(ISender sender,IHubContext<ChatHub> hubContext) : ControllerBase
{
    [HttpPost]
    public async Task SendMessage(string user, string message)
    {
        await hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    [HttpPost]
    public async Task<ActionResult<Result>> SendMessageToUser(MessageToUserRequest request)
    {
        var command = new SendMessageToUserCommand(request);

        var response = await sender.Send(command);

        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }

}
