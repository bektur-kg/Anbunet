namespace Anbunet.Application.Features.Comments.Update;

public record UpdateCommentCommand(long CommentId, UpdateCommentRequest Data) : ICommand<Result>;