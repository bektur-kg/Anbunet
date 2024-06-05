using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Anbunet.Application.Contracts.Stories;

public record CreateStoryRequest
{
    [Required]
    public required IFormFile File { get; set; }
}

