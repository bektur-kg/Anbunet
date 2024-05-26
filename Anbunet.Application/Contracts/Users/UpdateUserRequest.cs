using Anbunet.Domain.Modules.Users;
using System.ComponentModel.DataAnnotations;

namespace Anbunet.Application.Contracts.Users;

public record UpdateUserRequest
{
    [Required]
    public long UserId { get; set; }

    [EmailAddress]
    [MaxLength(UserAttributeConstants.MAX_EMAIL_LENGTH)]
    public string? Email { get; set; }

    [MaxLength(UserAttributeConstants.MAX_FULLNAME_LENGTH)]
    public string? Fullname { get; set; }

    [Url]
    public string? ProfilePicture { get; set; }

    [MaxLength(UserAttributeConstants.MAX_BIO_LENGTH)]
    public string? Bio { get; set; }

    public Gender Gender { get; set; }
}
