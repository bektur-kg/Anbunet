namespace Anbunet.Application.Features.Stories.GetAllStories;

public record GetFollowingStoriesQuery : IQuery<ValueResult<List<FollowingStoriesResponse>>>;