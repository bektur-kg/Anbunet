using Anbunet.Application.Contracts.Follows;
using Anbunet.Application.Features.Follows.CreateFollowers;
using Anbunet.Application.Features.Follows.Delete;
using Anbunet.Application.Features.Follows.GetFollowers;
using Anbunet.Application.Features.Follows.GetFollowings;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anbunet.API.Controllers;
[Authorize]
[Route("api")]
[ApiController]
public class FollowController(ISender sender) : ControllerBase
{
    [HttpGet("/followers/{userId}")]
    public async Task<ActionResult<ValueResult<List<FollowResponse>>>> GetAllFollowers(long userId)
    {
        var command = new GetUserFollowersQuery(userId);

        var response = await sender.Send(command);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpGet("/followings/{userId}")]
    public async Task<ActionResult<ValueResult<List<FollowResponse>>>> GetAllFollowings(long userId)
    {
        var command = new GetUserFollowingsQuery(userId);

        var response = await sender.Send(command);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpPost("/follow/{userId}")]
    public async Task<ActionResult<Result>> Subscribe(long userId)
    {
        var command = new CreateFollowingCommand(userId);

        var response = await sender.Send(command);

        return response.IsSuccess ? Ok(response.IsSuccess) : BadRequest(response.Error);
    }

    [HttpDelete("/following/{userId}")]
    public async Task<ActionResult<Result>> DeleteFollowing(long userId)
    {
        var command = new DeleteFollowingCommand(userId);

        var response = await sender.Send(command);

        return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
    }
}
