using Anbunet.Application.Abstractions;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Comments.Delete;

public record DeleteCommentCommand(long CommentId) : ICommand<Result>;
