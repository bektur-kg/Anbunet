namespace Anbunet.Application.Features.Posts.GetById;

public record GetPostByIdQuery(long Id) : IQuery<ValueResult<PostDetailedResponse>>;