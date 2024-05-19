using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Users;

public static class UserErrors
{
    public static Error UserNotFound = new("User.UserNotFound", "User is not found");
    public static Error WrongPassword = new("User.WrongPassword", "Provided password is wrong");
    public static Error LoginAlreadyExists = new("User.LoginAlreadyExists", "Provided login already is taken");
}

