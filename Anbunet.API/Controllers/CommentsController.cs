using Anbunet.Application.Contracts.Comments;
using Anbunet.Application.Features.Comments.Delete;
using Anbunet.Application.Features.Comments.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anbunet.API.Controllers;

[Authorize]
[ApiController]
public class CommentsController(ISender sender) : ControllerBase
{
    [HttpDelete("posts/comment/{id:long}")]
    public async Task<ActionResult> Delete(long id)
    {
        var command = new DeleteCommentCommand(id);

        var response = await sender.Send(command);

        return response.IsSuccess ? NoContent() : BadRequest(response.Error);
    }

    [HttpPatch("posts/comment/{id:long}")]
    public async Task<ActionResult> Update(long id, UpdateCommentRequest dto)
    {
        var command = new UpdateCommentCommand(id, dto);

        var response = await sender.Send(command);

        return response.IsSuccess ? NoContent() : BadRequest(response.Error);
    }
}
