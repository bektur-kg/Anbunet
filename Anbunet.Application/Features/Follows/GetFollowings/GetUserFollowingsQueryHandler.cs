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
        var foundUser = await userRepository.GetByIdWithIncludeAsync(request.UserId,includeFollowings:true);

        if (foundUser is null) return ValueResult<List<FollowResponse>>.Failure(UserErrors.UserNotFound);

        var followings = foundUser.Followings.ToList();

        var result = _mapper.Map<List<FollowResponse>>(followings);

        return ValueResult<List<FollowResponse>>.Success(result);
    }
}