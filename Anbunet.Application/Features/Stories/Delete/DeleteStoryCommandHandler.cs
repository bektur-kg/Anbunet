namespace Anbunet.Application.Features.Stories.Delete;

public class DeleteStoryCommandHandler
    (
        IStoryRepository storyRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
    : ICommandHandler<DeleteStoryCommand, Result>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(DeleteStoryCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var story = await storyRepository.GetByIdAsyncAndTracking(request.Id);

        if (story == null) return Result.Failure(StoriesErrors.StoriesNotFound);
        if (story.UserId != userId) return Result.Failure(StoriesErrors.YouCanDeleteOnlyYourStory);

        storyRepository.Remove(story);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}