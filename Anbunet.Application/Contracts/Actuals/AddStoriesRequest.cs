namespace Anbunet.Application.Contracts.Actuals;

public record AddStoriesRequest
{
    [Required]
    public long StoryId { get; set; }
}