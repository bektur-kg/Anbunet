namespace Anbunet.Application.Contracts.Comments;

public class CommentResponse
{
    public long Id { get; set; }

    public required string Text { get; set; }

    public DateTime CreatedDate { get; set; }

    public UserCommentResponse? User { get; set; }
}