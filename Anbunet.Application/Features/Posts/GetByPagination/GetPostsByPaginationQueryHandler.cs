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
        var foundPosts = await postRepository.GetPostsByPaginationWithIncludeAsync(request.Page, request.Quantity, includeComments: true, includeLikes: true, includeUser: true);

        if (foundPosts is null) return ValueResult<List<PostDetailedResponse>>.Failure(PostErrors.PostNotFound);

        var mappedPosts = mapper.Map<List<PostDetailedResponse>>(foundPosts);

        return ValueResult<List<PostDetailedResponse>>.Success(mappedPosts);
    }
}