using Anbunet.Domain.Modules.Posts;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Anbunet.Application.Contracts.Posts;

public record PostCreateRequest
{
    public required IFormFile File { get; set; }

    [MaxLength(PostAttributeConstants.MAX_DESCRIPTION_LENGTH)]
    public string? Desciption { get; set; }
}

