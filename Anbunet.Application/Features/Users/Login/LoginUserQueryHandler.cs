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

        if (user is null) return ValueResult<UserTokenResponse>.Failure(UserErrors.WrongCredentials);

        var isPasswordVerified = passwordManager.Verify(request.Data.Password, user.PasswordHash);

        if (!isPasswordVerified) return ValueResult<UserTokenResponse>.Failure(UserErrors.WrongCredentials);

        var token = jwtProvider.Generate(user);

        var response = new UserTokenResponse { Token = token };

        return ValueResult<UserTokenResponse>.Success(response);
    }
}