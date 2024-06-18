namespace Anbunet.Application.Features.Users;

public static class UserErrors
{
    public static readonly Error UserNotFound = new("User.UserNotFound", "User is not found");
    public static readonly Error LoginAlreadyExists = new("User.LoginAlreadyExists", "Provided login already is taken");
    public static readonly Error OldPasswordIsIncorrect = new("User.OldPasswordIsIncorrect", "Old password is incorrect");
    public static readonly Error WrongCredentials = new("User.WrongCredentials", "Wrong credentials");
}