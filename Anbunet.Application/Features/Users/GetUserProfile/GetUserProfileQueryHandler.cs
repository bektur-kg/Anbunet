namespace Anbunet.Application.Features.Users.GetUserProfile;

public class GetUserProfileQueryHandler
    (
        IUserRepository userRepository,
        IPostRepository postRepository,
        IMapper mapper
    )
    : IQueryHandler<GetUserProfileQuery, ValueResult<UserDetailedResponse>>
{
    public async Task<ValueResult<UserDetailedResponse>> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        var foundUser = await userRepository.GetByIdWithIncludeAsync(request.UserId, includeActuals: true, 
            includeStories: true, includeFollowers: true, includeFollowings: true);

        var userPosts = await postRepository.GetPostsByUserIdWithIncludeAsync(request.UserId, includeLikes: true, includeComments: true);

        if (foundUser is null) return ValueResult<UserDetailedResponse>.Failure(UserErrors.UserNotFound);

        var mappedUser = mapper.Map<UserDetailedResponse>(foundUser);
        var mappedUserPosts = mapper.Map<List<ProfilePostResponse>>(userPosts);

        mappedUser.FollowersCount = foundUser.Followers.Count;
        mappedUser.FollowingsCount = foundUser.Followings.Count;
        mappedUser.Posts = mappedUserPosts;

        return ValueResult<UserDetailedResponse>.Success(mappedUser);
    }
}