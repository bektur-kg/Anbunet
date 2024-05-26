using Anbunet.Application.Features.Likes.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anbunet.API.Controllers;

[Authorize]
[ApiController]
public class LikesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost("posts/{id:long}")]
    public async Task<ActionResult> Create(long id)
    {
        var command = new CreateLikeCommand(id);

        var response = await sender.Send(command);

        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }
}
