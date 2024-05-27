using Anbunet.Domain.Modules.Users;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Anbunet.Application.Contracts.Users;

public record UpdateUserRequest
{
    [EmailAddress]
    [MaxLength(UserAttributeConstants.MAX_EMAIL_LENGTH)]
    public string? Email { get; set; }

    [MaxLength(UserAttributeConstants.MAX_FULLNAME_LENGTH)]
    public string? Fullname { get; set; }

    public IFormFile? ProfilePicture { get; set; }

    [MaxLength(UserAttributeConstants.MAX_BIO_LENGTH)]
    public string? Bio { get; set; }

    public Gender Gender { get; set; }
}
