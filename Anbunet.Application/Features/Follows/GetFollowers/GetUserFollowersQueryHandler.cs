namespace Anbunet.Application.Features.Follows.GetFollowers;

public class GetUserFollowersQueryHandler
(
        IUserRepository userRepository,
        IMapper _mapper
    )
    : ICommandHandler<GetUserFollowersQuery, ValueResult<List<FollowResponse>>>
{
    public async Task<ValueResult<List<FollowResponse>>> Handle(GetUserFollowersQuery request, CancellationToken cancellationToken)
    {
        var foundUser = await userRepository.GetByIdWithIncludeAsync(request.UserId, includeFollowers:true);

        if (foundUser is null) return ValueResult<List<FollowResponse>>.Failure(UserErrors.UserNotFound);

        var followers = foundUser.Followers.ToList();

        var result = _mapper.Map<List<FollowResponse>>(followers);

        return ValueResult<List<FollowResponse>>.Success(result);
    }
}