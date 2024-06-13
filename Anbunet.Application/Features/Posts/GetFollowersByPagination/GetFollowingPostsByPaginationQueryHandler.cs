namespace Anbunet.Application.Features.Posts.GetFollowersByPagination;

public class GetFollowingPostsByPaginationQueryHandler
    (
        IUserRepository userRepository,
        IPostRepository postRepository,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper
    )
    : IQueryHandler<GetFollowingPostsByPaginationQuery, ValueResult<List<PostDetailedResponse>>>
{
    private readonly HttpContext httpContext = httpContextAccessor.HttpContext!;

    public async Task<ValueResult<List<PostDetailedResponse>>> Handle(GetFollowingPostsByPaginationQuery request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var followingIds = await userRepository.GetFollowingsIdsAsync(userId);
        if (followingIds == null || !followingIds.Any())
        {
            return ValueResult<List<PostDetailedResponse>>.Success(new List<PostDetailedResponse> { });
        }

        var followingPosts = await postRepository.GetPostsByUserIdsWithIncludeAsync(request.Page, request.Quantity, followingIds, includeComments:true, includeLikes:true, includeUser:true);
        var mappedPosts = mapper.Map<List<PostDetailedResponse>>(followingPosts);

        return ValueResult<List<PostDetailedResponse>>.Success(mappedPosts);
    }
}