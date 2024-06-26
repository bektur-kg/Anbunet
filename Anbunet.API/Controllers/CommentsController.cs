﻿using Anbunet.Application.Contracts.Comments;
using Anbunet.Application.Features.Comments.CreateComment;
using Anbunet.Application.Features.Comments.Delete;
using Anbunet.Application.Features.Comments.GetAllComments;
using Anbunet.Application.Features.Comments.Update;

namespace Anbunet.API.Controllers;

[Authorize]
[Route("api")]
[ApiController]
public class CommentsController(ISender sender) : ControllerBase
{
    [HttpGet("posts/{postId:long}/comments")]
    public async Task<ActionResult<ValueResult<List<CommentResponse>>>> GetAll(long postId)
    {
        var query = new GetAllCommentsByPostIdQuery(postId);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpPost("posts/{postId}/comments")]
    public async Task<ActionResult<Result>> Create(long postId, CommentRequest dto)
    {
        var command = new CreateCommentCommand(postId, dto);

        var response = await sender.Send(command);

        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }

    [HttpPut("posts/comments/{commentId}")]
    public async Task<ActionResult<Result>> Update(long commentId, UpdateCommentRequest dto)
    {
        var command = new UpdateCommentCommand(commentId, dto);

        var response = await sender.Send(command);

        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }

    [HttpDelete("posts/comments/{id:long}")]
    public async Task<ActionResult<Result>> Delete(long id)
    {
        var command = new DeleteCommentCommand(id);

        var response = await sender.Send(command);

        return response.IsSuccess ? NoContent() : BadRequest(response.Error);
    }
}
