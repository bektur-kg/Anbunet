using Anbunet.Application.Contracts.Users;
using Anbunet.Application.Abstractions;
using Anbunet.Domain.Modules.Users;
using Anbunet.Domain.Abstractions;
using AutoMapper;

namespace Anbunet.Application.Features.Users.GettingUsersByLogin;

public class GettingUsersByLoginQueryHandler
    (
        IUserRepository userRepository,
        IMapper mapper
    )
    : IQueryHandler<GettingUsersByLoginQuery, ValueResult<List<UserDetailedResponse>>>
{
    public async Task<ValueResult<List<UserDetailedResponse>>> Handle(GettingUsersByLoginQuery request, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetUsersByLoginAsync(request.Login);

        if (users.Count == 0) return ValueResult<List<UserDetailedResponse>>.Failure(UserErrors.UserNotFound);

        var mappedUsers = mapper.Map<List<UserDetailedResponse>>(users);

        return ValueResult<List<UserDetailedResponse>>.Success(mappedUsers);
    }
}