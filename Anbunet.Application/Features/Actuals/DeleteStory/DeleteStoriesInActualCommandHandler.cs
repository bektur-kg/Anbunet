namespace Anbunet.Application.Features.Actuals.DeleteStory;

public class DeleteStoriesInActualCommandHandler(
        IUserRepository userRepository,
        IStoryRepository storyRepository,
        IActualRepository actualRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
    : ICommandHandler<DeleteStoriesInActualCommand, Result>
{
    public readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(DeleteStoriesInActualCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var user = await userRepository.GetByIdWithIncludeAndTrackingAsync(userId, includeActuals: true);
        if (user == null) return Result.Failure(UserErrors.UserNotFound);

        var userActual = user.Actuals.FirstOrDefault(a => a.Id == request.Data.ActualId);
        if (userActual == null) return Result.Failure(ActualErrors.ActualNotFound);
        var actual = actualRepository.GetByIdWithIncludeAndTrackedAsync(request.Data.ActualId, includeStories: true).Result;
        if (actual == null) return Result.Failure(ActualErrors.ActualNotFound);

        var story = await storyRepository.GetByIdAsyncAndTracking(request.Data.StoryId);
        if (story == null) return Result.Failure(ActualErrors.ActualNotFound);
        var result = actual.Stories.Remove(story);
        if (!result) return Result.Failure(StoriesErrors.StoriesNotFound);


        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}