﻿using Anbunet.Application.Contracts.Users;
using Anbunet.Application.Features.Likes.Create;
using Anbunet.Application.Features.Likes.Delete;
using Anbunet.Application.Features.Likes.GetAll;

namespace Anbunet.API.Controllers;

[Authorize]
[Route("api")]
[ApiController]
public class LikesController(ISender sender) : ControllerBase
{
    [HttpPost("posts/{id:long}/likes")]
    public async Task<ActionResult> Create(long id)
    {
        var command = new CreateLikeCommand(id);

        var response = await sender.Send(command);

        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }

    [HttpGet("posts/{id:long}/likes")]
    public async Task<ActionResult<ValueResult<List<UserLikeResponse>>>> GetAll(long id)
    {
        var command = new GetAllLikeQuery(id);

        var response = await sender.Send(command);

        return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
    }

    [HttpDelete("posts/{id:long}/likes")]
    public async Task<ActionResult> Delete(long id)
    {
        var command = new DeleteLikeCommand(id);

        var response = await sender.Send(command);

        return response.IsSuccess ? NoContent() : BadRequest(response.Error);
    }
}
