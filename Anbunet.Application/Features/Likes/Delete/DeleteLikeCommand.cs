namespace Anbunet.Application.Features.Likes.Delete;

public record DeleteLikeCommand(long PostId) : ICommand<Result>;