namespace Anbunet.Application.Contracts.Users;

public record UpdateUserRequest
{
    [EmailAddress]
    [MaxLength(UserAttributeConstants.MAX_EMAIL_LENGTH)]
    public string? Email { get; set; }

    [MaxLength(UserAttributeConstants.MAX_FULLNAME_LENGTH)]
    public string? Fullname { get; set; }

    [MaxLength(UserAttributeConstants.MAX_BIO_LENGTH)]
    public string? Bio { get; set; }

    public Gender? Gender { get; set; }
}