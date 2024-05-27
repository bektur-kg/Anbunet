using Microsoft.AspNetCore.Http;

namespace Anbunet.Application.Contracts.Stories;

public record CreateStoryRequest
{
    public required IFormFile File { get; set; }
}

