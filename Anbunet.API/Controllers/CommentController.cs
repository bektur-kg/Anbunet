using Anbunet.Application.Contracts.Comments;
using Anbunet.Application.Contracts.Posts;
using Anbunet.Application.Features.Comments.CreateComment;
using Anbunet.Application.Features.Comments.GetAllComments;
using Anbunet.Application.Features.Posts.Create;
using Anbunet.Application.Features.Posts.GetById;
using Anbunet.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anbunet.API.Controllers;

[ApiController]
[Route("comments")]
[Authorize]
public class CommentController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Result>> Create(CommentRequest dto)
    {
        var command = new CreateCommentCommand(dto);

        var response = await sender.Send(command);

        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }

    [HttpGet("{postId:long}")]
    public async Task<ActionResult<ValueResult<List<CommentResponse>>>> GetAll(long postId)
    {
        var query = new GetAllCommentsByPostIdQuery(postId);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }
}