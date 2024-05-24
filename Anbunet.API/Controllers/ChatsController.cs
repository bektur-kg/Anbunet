using Anbunet.Application.Hubs;
using Anbunet.Application.Contracts.Chats;
using Anbunet.Application.Features.Chats.SendMessageToUser;
using Anbunet.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Anbunet.Application.Controllers;
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
