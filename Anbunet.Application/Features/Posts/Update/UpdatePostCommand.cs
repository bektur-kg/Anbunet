namespace Anbunet.Application.Features.Posts.Update;

public record UpdatePostCommand(long Id, PostUpdateRequest Data) : ICommand<Result>;