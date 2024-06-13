namespace Anbunet.Application.Features.Follows.GetFollowers;

public record GetUserFollowersQuery(long UserId) : ICommand<ValueResult<List<FollowResponse>>>;