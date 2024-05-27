using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Follows;
using Anbunet.Application.Features.Follows.GetFollowers;
using Anbunet.Application.Features.Users;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Users;
using AutoMapper;

namespace Anbunet.Application.Features.Follows.GetFollowings;

public class GetUserFollowingsCommandHandler
(
        IUserRepository userRepository,
        IMapper _mapper
    )
    : ICommandHandler<GetUserFollowingsCommand, ValueResult<List<FollowRequest>>>
{
    public async Task<ValueResult<List<FollowRequest>>> Handle(GetUserFollowingsCommand request, CancellationToken cancellationToken)
    {
        var foundUser = await userRepository.GetByIdAsync(request.userId);

        if (foundUser is null) return ValueResult<List<FollowRequest>>.Failure(UserErrors.UserNotFound);

        var followings = foundUser.Followings.ToList();

        var result = _mapper.Map<List<FollowRequest>>(followings);

        return ValueResult<List<FollowRequest>>.Success(result);
    }
}
