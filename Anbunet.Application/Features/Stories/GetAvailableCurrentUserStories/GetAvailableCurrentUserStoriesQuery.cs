namespace Anbunet.Application.Features.Stories.GetAllCurrentUserStories;

public record GetAvailableCurrentUserStoriesQuery : IQuery<ValueResult<List<ProfileStoryResponse>>>;