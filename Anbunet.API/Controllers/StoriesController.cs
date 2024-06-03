using Anbunet.Application.Contracts.Stories;
using Anbunet.Application.Features.Stories.Create;
using Anbunet.Application.Features.Stories.Delete;
using Anbunet.Application.Features.Stories.GetById;
using Anbunet.Application.Features.Stories.GetUserStories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anbunet.API.Controllers;

[ApiController]
[Authorize]
public class StoriesController(ISender sender) : ControllerBase
{
    [HttpGet("users/{id:long}/stories")]
    public async Task<ActionResult<List<ProfileStoryResponse>>> GetUserStories(long id)
    {
        var query = new GetUserStoriesQuery(id);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpGet("user/{id:long}/stories")]//change this path
    public async Task<ActionResult<List<ProfileStoryResponse>>> GetById(long id)
    {
        var query = new GetStoriesByIdQuery(id);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpPost("users/profile/stories")]
    public async Task<ActionResult<List<ProfileStoryResponse>>> CreateStory(CreateStoryRequest dto)
    {
        var command = new CreateStoryCommand(dto);

        var response = await sender.Send(command);

        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }

    [HttpDelete("user/{id:long}/stories")]//change this path
    public async Task<ActionResult<List<ProfileStoryResponse>>> Delete(long id)
    {
        var command = new DeleteStoriesCommand(id);

        var response = await sender.Send(command);

        return response.IsSuccess ? NoContent() : BadRequest(response.Error);
    }
}
