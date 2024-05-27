using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Posts;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Posts.GetByPagination;

public record GetPostsByPaginationQuery(int Page, int Quantity) : IQuery<ValueResult<List<PostDetailedResponse>>>;

