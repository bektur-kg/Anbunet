using Anbunet.Application.Contracts.Chats;
using Anbunet.Application.Features.Chats.Create;
using Anbunet.Application.Features.Chats.GetChats;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatsController(ISender sender,IHubContext<ChatHub> hubContext) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ValueResult<List<ContactResponse>>>> GetChats()
    {
        var command = new GetChatsQuery();

        var response = await sender.Send(command);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpPost]
    public async Task<ActionResult<ValueResult<CreateChatResponse>>> CreateChat(CreateChatRequest request)
    {
        var command = new CreateChatCommand(request.UserId);

        var response = await sender.Send(command);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

}
