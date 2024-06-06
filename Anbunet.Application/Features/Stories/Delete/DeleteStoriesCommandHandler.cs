using Anbunet.Application.Abstractions;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Stories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Stories.Delete;

public class DeleteStoriesCommandHandler
    (
        IStoryRepository storyRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
    : ICommandHandler<DeleteStoriesCommand, Result>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(DeleteStoriesCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var stories = await storyRepository.GetByIdAsyncAndTracking(request.Id);

        if (stories == null) return Result.Failure(StoriesErrors.StoriesNotFound);
        if (stories.UserId != userId) return Result.Failure(StoriesErrors.YouCanDeleteOnlyYourStory);

        storyRepository.Remove(stories);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}