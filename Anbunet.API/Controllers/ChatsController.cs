using Anbunet.API.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Anbunet.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ChatsController(IHubContext<ChatHub> hubContext) : ControllerBase
{
    [HttpPost]
    public async Task SendMessage(string user, string message)
    {
        await hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
