namespace Anbunet.Application.Contracts.Comments;

public record CommentRequest
{
    [MaxLength(CommentAttributeConstants.MAX_TEXT_LENGTH)]
    public required string Text { get; set; }
}