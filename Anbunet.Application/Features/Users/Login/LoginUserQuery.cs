namespace Anbunet.Application.Features.Users.Login;

public record LoginUserQuery(LoginUserRequest Data) : IQuery<ValueResult<UserTokenResponse>>;