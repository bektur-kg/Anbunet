namespace Anbunet.Application.Features.Actuals.AddStories;

public class AddStoriesInActualCommandHandler
(
        IActualRepository actualRepository,
        IUserRepository userRepository,
        IStoryRepository storyRepository,
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<AddStoriesInActualCommand, Result>
{
    public readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;
    public async Task<Result> Handle(AddStoriesInActualCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var user = await userRepository.GetByIdAsync(userId);
        if (user == null) return Result.Failure(UserErrors.UserNotFound);

        var story = await storyRepository.GetByIdWithIncludeAsync(request.Data.StoryId, includeUser: true);
        if (story == null || story.User.Id != userId) return Result.Failure(StoriesErrors.StoriesNotFound);

        var actual = await actualRepository.GetByIdWithIncludeAndTrackedAsync(request.ActualId, includeStories: true);
        if (actual == null) return Result.Failure(ActualErrors.ActualNotFound);
        if (actual.Stories.Any(a => a.Id == story.Id)) return Result.Failure(ActualErrors.ThereIsAlreadySuchStory);

        actual.Stories.Add(story);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}