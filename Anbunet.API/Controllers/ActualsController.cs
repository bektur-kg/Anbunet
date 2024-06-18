using Anbunet.Application.Contracts.Actuals;
using Anbunet.Application.Features.Actuals.AddStories;
using Anbunet.Application.Features.Actuals.CreateActuals;
using Anbunet.Application.Features.Actuals.Delete;
using Anbunet.Application.Features.Actuals.DeleteStory;
using Anbunet.Application.Features.Actuals.GetActualsById;
using Anbunet.Application.Features.Actuals.GetUserActuals;
using Anbunet.Application.Features.Actuals.Update;

namespace Anbunet.API.Controllers;

[Authorize]
[ApiController]
[Route("api")]
public class ActualsController(ISender sender) : ControllerBase
{
    [HttpGet("actuals/{actualId:long}")]
    public async Task<ActionResult<ValueResult<ProfileActualResponse>>> GetById(long actualId)
    {
        var query = new GetActualsByIdQuery(actualId);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpGet("users/{userId}/actuals")]
    public async Task<ActionResult<ValueResult<List<ProfileActualResponse>>>> GetAllByUserId(long userId)
    {
        var query = new GetAllActualsByUserIdQuery(userId);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpPost("actuals/{actualId}/stories")]
    public async Task<ActionResult<Result>> AddStory(long actualId, AddStoriesRequest dto)
    {
        var query = new AddStoriesInActualCommand(actualId, dto);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.IsSuccess) : BadRequest(response.Error);
    }

    [HttpPost("actuals")]
    public async Task<ActionResult<ValueResult<CreateActualResponse>>> Create(CreateActualRequest dto)
    {
        var query = new CreateActualsCommmand(dto);

        var response = await sender.Send(query);    

        return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
    }

    [HttpDelete("actuals/{actualId}")]
    public async Task<ActionResult<Result>> Delete(long actualId)
    {
        var command = new DeleteActualCommand(actualId);

        var response = await sender.Send(command);

        return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
    }

    [HttpDelete("actuals/{actualId}/stories/{storyId}")]
    public async Task<ActionResult<Result>> DeleteStory(long actualId, long storyId)
    {
        var query = new DeleteStoriesInActualCommand(actualId, storyId);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.IsSuccess) : BadRequest(response.Error);
    }

    [HttpPut("actuals/{actualId}")]
    public async Task<ActionResult<Result>> Update(long actualId, UpdateActualRequest request)
    {
        var query = new UpdateActualCommand(actualId, request);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.IsSuccess) : BadRequest(response.Error);
    }
}