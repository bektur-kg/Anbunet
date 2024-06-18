namespace Anbunet.Application.Features.Users.GettingUsersByLogin;

public class GettingUsersByLoginQueryHandler
    (
        IUserRepository userRepository,
        IMapper mapper
    )
    : IQueryHandler<GettingUsersByLoginQuery, ValueResult<List<UsersSearchResponse>>>
{
    public async Task<ValueResult<List<UsersSearchResponse>>> Handle(GettingUsersByLoginQuery request, CancellationToken cancellationToken)
    {
        if(request.Login.IsNullOrEmpty()) return ValueResult<List<UsersSearchResponse>>.Success(new());

        var users = await userRepository.GetUsersByLoginAsync(request.Login);

        var mappedUsers = mapper.Map<List<UsersSearchResponse>>(users);

        return ValueResult<List<UsersSearchResponse>>.Success(mappedUsers);
    }
}