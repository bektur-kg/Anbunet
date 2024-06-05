using System.ComponentModel.DataAnnotations;

namespace Anbunet.Application.Contracts.Users;

public class UserUpdatePasswordRequest
{
    [Required]
    public string OldPassword { get; set; }
    [Required]
    public string NewPassword { get; set; }

}
