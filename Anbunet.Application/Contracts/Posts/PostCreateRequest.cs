namespace Anbunet.Application.Contracts.Posts;

public record PostCreateRequest
{
    public required IFormFile File { get; set; }

    [MaxLength(PostAttributeConstants.MAX_DESCRIPTION_LENGTH)]
    public string? Description { get; set; }
}