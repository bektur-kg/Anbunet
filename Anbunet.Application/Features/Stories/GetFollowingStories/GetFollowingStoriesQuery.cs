namespace Anbunet.Application.Features.Stories.GetFollowingStories;

public record GetFollowingStoriesQuery : IQuery<ValueResult<List<FollowingStoriesResponse>>>;