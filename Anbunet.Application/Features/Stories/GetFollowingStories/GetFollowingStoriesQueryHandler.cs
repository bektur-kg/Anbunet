namespace Anbunet.Application.Features.Stories.GetAllStories;

public class GetFollowingStoriesQueryHandler
    (
        IHttpContextAccessor httpContextAccessor,
        IUserRepository userRepository,
        IMapper mapper
    )
    : IQueryHandler<GetFollowingStoriesQuery, ValueResult<List<FollowingStoriesResponse>>>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;
    public async Task<ValueResult<List<FollowingStoriesResponse>>> Handle(GetFollowingStoriesQuery request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var currentUser = await userRepository.GetByIdWithIncludeAsync(userId, includeFollowings: true);

        List<FollowingStoriesResponse> followingStories = new();

        foreach ( var user in currentUser.Followings )
        {
            var userIncludeStories = await userRepository.GetByIdWithIncludeAsync(user.Id, includeStories: true);
            userIncludeStories.Stories = userIncludeStories.Stories.OrderByDescending(s=>s.CreatedDate).ToList();
            var userResponse = mapper.Map<FollowingStoriesResponse>(userIncludeStories);
            followingStories.Add(userResponse);
        }

        followingStories = followingStories.OrderByDescending( f => f.Stories.Max(s=>s.Id)).ToList();

        return ValueResult<List<FollowingStoriesResponse>>.Success(followingStories);
    }
}