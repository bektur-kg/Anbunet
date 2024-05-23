using Anbunet.Application.Contracts.Posts;
using Anbunet.Application.Features.Posts.Create;
using Anbunet.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anbunet.API.Controllers;

[ApiController]
[Route("posts")]
[Authorize]
public class PostsController(ISender sender) : ControllerBase
{  
    [HttpPost]
    public async Task<ActionResult<Result>> Create(PostCreateRequest dto)
    {
        var command = new CreatePostCommand(dto);

        var response = await sender.Send(command);

        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }
}
