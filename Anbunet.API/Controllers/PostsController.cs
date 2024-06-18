using Anbunet.Application.Contracts.Posts;
using Anbunet.Application.Features.Posts.Create;
using Anbunet.Application.Features.Posts.Delete;
using Anbunet.Application.Features.Posts.GetById;
using Anbunet.Application.Features.Posts.Update;
using Anbunet.Application.Features.Posts.GetByPagination;
using Anbunet.Application.Features.Posts.GetFollowersByPagination;

namespace Anbunet.Application.Controllers;

[ApiController]
[Route("api")]
[Authorize]
public class PostsController(ISender sender) : ControllerBase
{
    [HttpGet("posts/{id:long}")]
    public async Task<ActionResult<ValueResult<PostDetailedResponse>>> GetById(long id)
    {
        var query = new GetPostByIdQuery(id);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpPost("posts")]
    public async Task<ActionResult<Result>> Create(PostCreateRequest dto)
    {
        var command = new CreatePostCommand(dto);

        var response = await sender.Send(command);

        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }

    [HttpPatch("posts/{id:long}")]
    public async Task<ActionResult<Result>> Update(long id, PostUpdateRequest request)
    {
        var query = new UpdatePostCommand(id, request);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response) : BadRequest(response.Error);
    }

    [HttpDelete("posts/{id:long}")]
    public async Task<ActionResult<Result>> Delete(long id)
    {
        var query = new DeletePostCommand(id);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response) : BadRequest(response.Error);

    }

    [HttpGet("popular-posts")]
    public async Task<ActionResult<ValueResult<List<PostDetailedResponse>>>> GetByPagination(int page, int quantity)
    {
        var query = new GetPostsByPaginationQuery(page, quantity);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpGet("following-users/posts")]
    public async Task<ActionResult<ValueResult<List<PostDetailedResponse>>>> GetFollowersByPagination(int page, int quantity)
    {
        var query = new GetFollowingPostsByPaginationQuery(page, quantity);

        var response = await sender.Send(query);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }
}
