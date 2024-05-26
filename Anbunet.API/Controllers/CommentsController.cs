using Anbunet.Application.Features.Comments.Delete;
using Anbunet.Application.Features.Likes.Delete;
using Anbunet.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anbunet.API.Controllers;
[Authorize]
[ApiController]
public class CommentsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpDelete("posts/comment/{id:long}")]
    public async Task<ActionResult> Delete(long id)
    {
        var command = new DeleteCommentCommand(id);

        var response = await sender.Send(command);

        return response.IsSuccess ? NoContent() : BadRequest(response.Error);
    }
}
