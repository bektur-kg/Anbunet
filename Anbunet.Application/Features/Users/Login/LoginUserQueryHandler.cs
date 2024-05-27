﻿using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Users;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Users;

namespace Anbunet.Application.Features.Users.Login;

public class LoginUserQueryHandler
    (
        IUserRepository userRepository,
        IJwtProvider jwtProvider,
        IPasswordManager passwordManager
    )
    : IQueryHandler<LoginUserQuery, ValueResult<UserTokenResponse>>
{
    public async Task<ValueResult<UserTokenResponse>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByLoginAsync(request.Data.Login);

        if (user is null) return ValueResult<UserTokenResponse>.Failure(UserErrors.UserNotFound);

        var isPasswordVerified = passwordManager.Verify(request.Data.Password, user.PasswordHash);

        if (!isPasswordVerified) return ValueResult<UserTokenResponse>.Failure(UserErrors.WrongPassword);

        var token = jwtProvider.Generate(user);

        var response = new UserTokenResponse { Token = token };

        return ValueResult<UserTokenResponse>.Success(response);
    }
}

