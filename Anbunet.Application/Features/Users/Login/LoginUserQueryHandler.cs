using Anbunet.Application.Abstractions;
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
    : IQueryHandler<LoginUserQuery, ValueResult<string>>
{
    public async Task<ValueResult<string>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByLoginAsync(request.Data.Login);

        if (user is null) return ValueResult<string>.Failure(UserErrors.UserNotFound);

        var isPasswordVerified = passwordManager.Verify(request.Data.Password, user.PasswordHash);

        if (!isPasswordVerified) return ValueResult<string>.Failure(UserErrors.WrongPassword);

        var token = jwtProvider.Generate(user);

        return ValueResult<string>.Success(token);
    }
}

