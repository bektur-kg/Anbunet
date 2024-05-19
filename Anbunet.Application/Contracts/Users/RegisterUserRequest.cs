using Anbunet.Domain.Modules.Users;
using System.ComponentModel.DataAnnotations;

namespace Anbunet.Application.Contracts.Users;

public record RegisterUserRequest
{
    [MaxLength(UserAttributeConstants.MAX_LOGIN_LENGTH)]
    public required string Login { get; set; }

    public required string Password { get; set; }
}

