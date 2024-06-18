namespace Anbunet.Application.Features.Follows.Create;

public record CreateFollowingCommand(long UserId) : ICommand<Result>;