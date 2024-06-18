using Anbunet.Application.Contracts.Follows;
using Anbunet.Application.Features.Follows.Create;
using Anbunet.Application.Features.Follows.Delete;
using Anbunet.Application.Features.Follows.GetFollowers;
using Anbunet.Application.Features.Follows.GetFollowings;

namespace Anbunet.API.Controllers;

[Authorize]
[Route("api")]
[ApiController]
public class FollowController(ISender sender) : ControllerBase
{
    [HttpGet("users/{userId}/followers")]
    public async Task<ActionResult<ValueResult<List<FollowResponse>>>> GetAllFollowers(long userId)
    {
        var command = new GetUserFollowersQuery(userId);

        var response = await sender.Send(command);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpGet("users/{userId}/followings")]
    public async Task<ActionResult<ValueResult<List<FollowResponse>>>> GetAllFollowings(long userId)
    {
        var command = new GetUserFollowingsQuery(userId);

        var response = await sender.Send(command);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpPost("users/{userId}/followers")]
    public async Task<ActionResult<Result>> Subscribe(long userId)
    {
        var command = new CreateFollowingCommand(userId);

        var response = await sender.Send(command);

        return response.IsSuccess ? Ok(response.IsSuccess) : BadRequest(response.Error);
    }

    [HttpDelete("users/{userId}/followers")]
    public async Task<ActionResult<Result>> DeleteFollowing(long userId)
    {
        var command = new DeleteFollowingCommand(userId);

        var response = await sender.Send(command);

        return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
    }
}
