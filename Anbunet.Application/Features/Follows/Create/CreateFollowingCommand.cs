namespace Anbunet.Application.Features.Follows.CreateFollowers;

public record CreateFollowingCommand(long UserId) : ICommand<Result>;