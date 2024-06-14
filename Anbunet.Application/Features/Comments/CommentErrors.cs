namespace Anbunet.Application.Features.Comments;

public abstract class CommentErrors
{
    public static readonly Error CommentNotFound = new("Comment.CommentNotFound", "Comment is not found");
    public static readonly Error CannotDeleteThisComment = new ("Comment.CannotDeleteThisComment", "You can't delete someone else's comment");
    public static readonly Error UserIsNotCommentAuthor = new ("Comment.UserIsNotCommentAuthor", "This user is not a comment author");
}