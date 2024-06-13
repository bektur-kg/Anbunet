namespace Anbunet.Application.Features.Comments.CreateComment;

public record CreateCommentCommand(long PostId, CommentRequest Data) : ICommand<Result>;