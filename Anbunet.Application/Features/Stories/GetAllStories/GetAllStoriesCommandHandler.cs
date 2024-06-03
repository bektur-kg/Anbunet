using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Stories;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Stories;
using AutoMapper;

namespace Anbunet.Application.Features.Stories.GetAllStories;

public class GetAllStoriesCommandHandler
    (
        IStoryRepository storyRepository,
        IMapper mapper
    )
    : ICommandHandler<GetAllStoriesCommand, ValueResult<List<ProfileStoryResponse>>>
{
    public async Task<ValueResult<List<ProfileStoryResponse>>> Handle(GetAllStoriesCommand request, CancellationToken cancellationToken)
    {
        var stories = await storyRepository.GetAllAsync();

        if (stories.Count == 0) return ValueResult<List<ProfileStoryResponse>>.Failure(StoriesErrors.StoriesNotFound);

        var mappedStories = mapper.Map<List<ProfileStoryResponse>>(stories);

        return ValueResult<List<ProfileStoryResponse>>.Success(mappedStories);
    }
}