using Anbunet.Domain.Modules.Comments;
using System.ComponentModel.DataAnnotations;

namespace Anbunet.Application.Contracts.Comments;

public record CommentRequest
{
    public long PostId { get; set; }

    [MaxLength(CommentAttributeConstants.MAX_TEXT_LENGTH)]
    public required string Text { get; set; }
}