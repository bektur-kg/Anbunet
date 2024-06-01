using Anbunet.Application.Contracts.Actuals;
using Anbunet.Application.Features.Actuals.AddStories;
using Anbunet.Application.Features.Actuals.CreateActuals;
using Anbunet.Application.Features.Actuals.GetActualsById;
using Anbunet.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anbunet.API.Controllers;

[Authorize]
[ApiController]
[Route("user/actual")]
public class ActualsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet("{actualId:long}")]
    public async Task<ActionResult<ValueResult<ProfileActualResponse>>> GetById(long actualId)
    {
        var query = new GetActualsByIdQuery(actualId);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpPost("add-story")]//change the path
    public async Task<ActionResult<Result>> AddStory(AddStoriesRequest dto)
    {
        var query = new AddStoriesInActualCommand(dto);

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
}