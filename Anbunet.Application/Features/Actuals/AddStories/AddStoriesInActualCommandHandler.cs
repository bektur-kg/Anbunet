using Anbunet.Application.Abstractions;
using Anbunet.Application.Features.Stories;
using Anbunet.Application.Features.Users;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Actuals;
using Anbunet.Domain.Modules.Stories;
using Anbunet.Domain.Modules.Users;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

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
    public readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
    public async Task<Result> Handle(AddStoriesInActualCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var user = await userRepository.GetByIdWithIncludeAndTrackingAsync(userId, includeStories: true, includeActuals:true);
        if (user == null) return Result.Failure(UserErrors.UserNotFound);

        var userActual = user.Actuals.FirstOrDefault(a=>a.Id==request.Data.ActualId);
        var story = user.Stories.FirstOrDefault(s=>s.Id==request.Data.StoryId);
        if (story == null) return Result.Failure(StoriesErrors.StoriesNotFound);
        if (userActual == null) return Result.Failure(ActualErrors.ActualNotFound);

        var actual = await actualRepository.GetByIdWithIncludeAndTracked(request.Data.ActualId, includeStories:true);
        if (actual == null) return Result.Failure(ActualErrors.ActualNotFound);
        if (actual.Stories.Any(a=>a.Id==story.Id)) return Result.Failure(ActualErrors.ThereIsAlreadySuchStory);

        actual.Stories.Add(story);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}