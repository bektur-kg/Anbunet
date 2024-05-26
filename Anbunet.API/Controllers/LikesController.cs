using Anbunet.Application.Contracts.Users;
using Anbunet.Application.Features.Likes.Create;
using Anbunet.Application.Features.Likes.Delete;
using Anbunet.Application.Features.Likes.GetAll;
using Anbunet.Domain.Abstractions;
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

    [HttpGet("posts/{id:long}/likes")]
    public async Task<ActionResult<ValueResult<List<UserLikeResponse>>>> GetAll(long id)
    {
        var command = new GetAllLikeCommand(id);

        var response = await sender.Send(command);

        return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
    }

    [HttpDelete("posts/{id:long}")]
    public async Task<ActionResult> Delete(long id)
    {
        var command = new DeleteLikeCommand(id);

        var response = await sender.Send(command);

        return response.IsSuccess ? NoContent() : BadRequest(response.Error);
    }
}
