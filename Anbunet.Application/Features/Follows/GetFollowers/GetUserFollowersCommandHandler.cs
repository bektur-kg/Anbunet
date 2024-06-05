using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Follows;
using Anbunet.Application.Contracts.Users;
using Anbunet.Application.Features.Posts;
using Anbunet.Application.Features.Users;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Domain.Modules.Users;
using AutoMapper;

namespace Anbunet.Application.Features.Follows.GetFollowers;

public class GetUserFollowersCommandHandler
(
        IUserRepository userRepository,
        IMapper _mapper
    )
    : IQueryHandler<GetUserFollowersCommand, ValueResult<List<FollowResponse>>>
{
    public async Task<ValueResult<List<FollowResponse>>> Handle(GetUserFollowersCommand request, CancellationToken cancellationToken)
    {
        var foundUser = await userRepository.GetByIdAsync(request.UserId);

        if (foundUser is null) return ValueResult<List<FollowResponse>>.Failure(UserErrors.UserNotFound);

        var followers = foundUser.Followers.ToList();

        var result = _mapper.Map<List<FollowResponse>>(followers);

        return ValueResult<List<FollowResponse>>.Success(result);
    }
}
