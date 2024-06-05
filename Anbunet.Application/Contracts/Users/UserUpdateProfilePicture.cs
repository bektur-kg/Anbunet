using Microsoft.AspNetCore.Http;

namespace Anbunet.Application.Contracts.Users;

public record UserUpdateProfilePicture
{
    public required IFormFile File { get; set; }
}

