namespace Anbunet.Application.Features.Users.GettingUsersByLogin;

public record GettingUsersByLoginQuery(string? Login) : IQuery<ValueResult<List<UsersSearchResponse>>>;