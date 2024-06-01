using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Posts;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;
using AutoMapper;

namespace Anbunet.Application.Features.Posts.GetByPagination;

public class GetPostsByPaginationQueryHandler
    (
        IPostRepository postRepository,
        IMapper mapper
    )
    : IQueryHandler<GetPostsByPaginationQuery, ValueResult<List<PostDetailedResponse>>>
{
    public async Task<ValueResult<List<PostDetailedResponse>>> Handle(GetPostsByPaginationQuery request, CancellationToken cancellationToken)
    {
        var foundPosts = await postRepository.GetPostsByPaginationWithInclude(request.Page, request.Quantity, includeComments: true, includeLikes: true, includeUser: true);

        if (foundPosts is null) return ValueResult<List<PostDetailedResponse>>.Failure(PostErrors.PostNotFound);

        foundPosts.ForEach(p => p.MediaUrl = ("https://localhost:7199/")+ p.MediaUrl);

        var mappedPosts = mapper.Map<List<PostDetailedResponse>>(foundPosts);

        return ValueResult<List<PostDetailedResponse>>.Success(mappedPosts);
    }
}
