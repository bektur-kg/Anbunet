namespace Anbunet.Application.Features.Comments.GetAllComments;

public record GetAllCommentsByPostIdQuery(long PostId) : IQuery<ValueResult<List<CommentResponse>>>;