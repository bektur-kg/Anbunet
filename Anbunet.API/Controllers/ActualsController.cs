using Anbunet.Application.Contracts.Actuals;
using Anbunet.Application.Features.Actuals.AddStories;
using Anbunet.Application.Features.Actuals.CreateActuals;
using Anbunet.Application.Features.Actuals.Delete;
using Anbunet.Application.Features.Actuals.DeleteStory;
using Anbunet.Application.Features.Actuals.GetActualsById;
using Anbunet.Application.Features.Actuals.Update;

namespace Anbunet.API.Controllers;

[Authorize]
[ApiController]
[Route("api/user/actuals")]
public class ActualsController(ISender sender) : ControllerBase
{
    [HttpGet("{actualId:long}")]
    public async Task<ActionResult<ValueResult<ProfileActualResponse>>> GetById(long actualId)
    {
        var query = new GetActualsByIdQuery(actualId);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpPost("{storyId}/story")]
    public async Task<ActionResult<Result>> AddStory(long storyId, AddStoriesRequest dto)
    {
        var query = new AddStoriesInActualCommand(storyId, dto);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.IsSuccess) : BadRequest(response.Error);
    }

    [HttpPost]
    public async Task<ActionResult<Result>> Create(CreateActualRequest dto)
    {
        var query = new CreateActualsCommmand(dto);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.IsSuccess) : BadRequest(response.Error);
    }

    [HttpDelete("{actualId}")]
    public async Task<ActionResult<Result>> Delete(long actualId)
    {
        var command = new DeleteActualCommand(actualId);

        var response = await sender.Send(command);

        return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
    }

    [HttpDelete("story")] // todo change for gettting actual id and story id from querry
    public async Task<ActionResult<Result>> DeleteStory(DeleteStoriesRequest request)
    {
        var query = new DeleteStoriesInActualCommand(request);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.IsSuccess) : BadRequest(response.Error);
    }

    [HttpPut] // todo change for getting actualId for getting from querry
    public async Task<ActionResult<Result>> Update(UpdateActualRequest request)
    {
        var query = new UpdateActualCommand(request);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.IsSuccess) : BadRequest(response.Error);
    }
}