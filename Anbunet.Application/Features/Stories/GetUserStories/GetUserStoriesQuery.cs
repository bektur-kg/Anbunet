namespace Anbunet.Application.Features.Stories.GetUserStories;

public record GetUserStoriesQuery(long UserId) : IQuery<ValueResult<List<ProfileStoryResponse>>>;