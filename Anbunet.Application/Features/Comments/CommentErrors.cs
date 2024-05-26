
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Comments;

public abstract class CommentErrors
{
    public static readonly Error CommentNotFound = new("Comment.CommentNotFound", "Comment is not found");
}