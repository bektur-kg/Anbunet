using System.ComponentModel.DataAnnotations;

namespace Anbunet.Application.Contracts.Actuals;

public record DeleteStoriesRequest
{
    [Required]
    public long StoryId { get; set; }

    [Required]
    public long ActualId { get; set; }
}