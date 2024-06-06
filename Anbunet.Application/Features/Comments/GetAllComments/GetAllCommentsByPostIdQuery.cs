using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Comments;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Comments.GetAllComments;

public record GetAllCommentsByPostIdQuery(long PostId) : IQuery<ValueResult<List<CommentResponse>>>;