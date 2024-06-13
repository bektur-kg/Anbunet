namespace Anbunet.Application.Contracts.Stories;

public record CreateStoryRequest
{
    [Required]
    public required IFormFile File { get; set; }
}