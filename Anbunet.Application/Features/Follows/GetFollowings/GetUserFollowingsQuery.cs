namespace Anbunet.Application.Features.Follows.GetFollowings;

public record GetUserFollowingsQuery(long UserId) : ICommand<ValueResult<List<FollowResponse>>>;