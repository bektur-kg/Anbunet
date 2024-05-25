using Anbunet.Application.Contracts.Stories;
using Anbunet.Application.Features.Posts.GetById;
using Anbunet.Application.Features.Stories.GetUserStories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Anbunet.API.Controllers;

[ApiController]
public class StoriesController(ISender sender) : ControllerBase
{
    [HttpGet("users/{id:long}/stories")]
    public async Task<ActionResult<List<ProfileStoryResponse>>> GetUserStories(long id)
    {
        var query = new GetUserStoriesQuery(id);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }
}
