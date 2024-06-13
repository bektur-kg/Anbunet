namespace Anbunet.Application.Features.Stories.GetMyselfStories;

public class GetMyselfStoriesQueryHandler
    (
        IStoryRepository storyRepository,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper
    )
    : IQueryHandler<GetMyselfStoriesQuery, ValueResult<List<ProfileStoryResponse>>>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<ValueResult<List<ProfileStoryResponse>>> Handle(GetMyselfStoriesQuery request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var stories = await storyRepository.GetStoriesByUserIdAsync(userId);
        var mappedStories = mapper.Map<List<ProfileStoryResponse>>(stories);
        return ValueResult<List<ProfileStoryResponse>>.Success(mappedStories);
    }
}