using System.ComponentModel.DataAnnotations;

namespace Anbunet.Application.Contracts.Actuals;

public record AddStoriesRequest
{
    [Required] 
    public long StoryId { get; set; }

    [Required]
    public long ActualId { get; set; }
}