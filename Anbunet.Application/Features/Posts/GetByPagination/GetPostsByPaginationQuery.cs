namespace Anbunet.Application.Features.Posts.GetByPagination;

public record GetPostsByPaginationQuery(int Page, int Quantity) : IQuery<ValueResult<List<PostDetailedResponse>>>;