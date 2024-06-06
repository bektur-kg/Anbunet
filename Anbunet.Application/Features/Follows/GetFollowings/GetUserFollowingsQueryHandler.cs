using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Follows;
using Anbunet.Application.Features.Follows.GetFollowers;
using Anbunet.Application.Features.Users;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Users;
using AutoMapper;

namespace Anbunet.Application.Features.Follows.GetFollowings;

public class GetUserFollowingsQueryHandler
(
        IUserRepository userRepository,
        IMapper _mapper
    )
    : ICommandHandler<GetUserFollowingsQuery, ValueResult<List<FollowResponse>>>
{
    public async Task<ValueResult<List<FollowResponse>>> Handle(GetUserFollowingsQuery request, CancellationToken cancellationToken)
    {
        var foundUser = await userRepository.GetByIdWithIncludeAndTrackingAsync(request.userId,includeFollowings:true);

        if (foundUser is null) return ValueResult<List<FollowResponse>>.Failure(UserErrors.UserNotFound);

        var followings = foundUser.Followings.ToList();

        var result = _mapper.Map<List<FollowResponse>>(followings);

        return ValueResult<List<FollowResponse>>.Success(result);
    }
}
