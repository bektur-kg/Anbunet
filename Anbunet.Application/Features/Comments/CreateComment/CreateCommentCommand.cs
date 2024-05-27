using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Comments;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Comments.CreateComment;

public record CreateCommentCommand(CommentRequest Data) : ICommand<Result>;