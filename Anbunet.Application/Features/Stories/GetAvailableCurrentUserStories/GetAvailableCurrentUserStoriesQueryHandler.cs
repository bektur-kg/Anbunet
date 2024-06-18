using System.Linq;

namespace Anbunet.Application.Features.Stories.GetAllCurrentUserStories;

public class GetAvailableCurrentUserStoriesQueryHandler
    (
        IStoryRepository storyRepository,
        IHttpContextAccessor httpContextAccessor,
        IActualRepository actualRepository,
        IMapper mapper
    )
    : IQueryHandler<GetAvailableCurrentUserStoriesQuery, ValueResult<List<ProfileStoryResponse>>>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<ValueResult<List<ProfileStoryResponse>>> Handle(GetAvailableCurrentUserStoriesQuery request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var takenStories = (await actualRepository.GetActualsByUserIdWithIncludeAsync(userId, includeStories: true))
            .SelectMany(actual => actual.Stories).ToList();

        var availableStories = (await storyRepository.GetAllCurrentUserStoriesAsync(userId))
            .Where(story => !takenStories.Any(takenStory => takenStory.Id == story.Id)).ToList();
        
        var mappedStories = mapper.Map<List<ProfileStoryResponse>>(availableStories);

        return ValueResult<List<ProfileStoryResponse>>.Success(mappedStories);
    }
}