namespace Anbunet.Application.Features.Posts.GetFollowersByPagination;

public record GetFollowingPostsByPaginationQuery(int Page, int Quantity) : IQuery<ValueResult<List<PostDetailedResponse>>>;