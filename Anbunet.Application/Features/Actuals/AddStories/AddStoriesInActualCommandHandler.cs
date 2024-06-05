using Anbunet.Application.Abstractions;
using Anbunet.Application.Features.Stories;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Actuals;
using Anbunet.Domain.Modules.Stories;

namespace Anbunet.Application.Features.Actuals.AddStories;

public class AddStoriesInActualCommandHandler
(
        IActualRepository actualRepository,
        IStoryRepository storyRepository,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<AddStoriesInActualCommand, Result>
{
    public async Task<Result> Handle(AddStoriesInActualCommand request, CancellationToken cancellationToken)
    {
        var story = await storyRepository.GetByIdAsync(request.Data.StoryId);
        if (story == null) return Result.Failure(StoriesErrors.StoriesNotFound);

        var actual = await actualRepository.GetByIdWithInclude(request.Data.ActualId, includeStories:true);
        if (actual == null) return Result.Failure(ActualErrors.ActualNotFound);
        if (actual.Stories.Any(a=>a.Id==story.Id)) return Result.Failure(ActualErrors.ThereIsAlreadySuchStory);

        actual.Stories.Add(story);
        actualRepository.Update(actual);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}