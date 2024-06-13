namespace Anbunet.Application.Features.Comments.Delete;

public record DeleteCommentCommand(long CommentId) : ICommand<Result>;