namespace Anbunet.Application.Features.Posts.Delete;

public record DeletePostCommand(long Id) : ICommand<Result>;