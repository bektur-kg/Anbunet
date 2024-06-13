using Anbunet.Application.Contracts.Chats;
using Anbunet.Application.Features.Chats.SendMessageToUser;

namespace Anbunet.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatsController(ISender sender,IHubContext<ChatHub> hubContext) : ControllerBase
{

    [HttpPost]
    public async Task<ActionResult<Result>> SendMessageToUser(MessageToUserRequest request)
    {
        var command = new SendMessageToUserCommand(request);

        var response = await sender.Send(command);

        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }

}
