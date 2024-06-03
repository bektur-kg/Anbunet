﻿using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Users;

namespace Anbunet.Application.Features.Users;

public static class UserErrors
{
    public static readonly Error UserNotFound = new("User.UserNotFound", "User is not found");
    public static readonly Error WrongPassword = new("User.WrongPassword", "Provided password is wrong");
    public static readonly Error LoginAlreadyExists = new("User.LoginAlreadyExists", "Provided login already is taken");
    public static readonly Error OldPasswordIsIncorrect = new("User.OldPasswordIsIncorrect", "Old password is incorrect");
}

