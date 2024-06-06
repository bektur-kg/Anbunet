using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Posts;
using Anbunet.Application.Contracts.Users;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Domain.Modules.Users;
using AutoMapper;

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
        var foundUser = await userRepository.GetByIdWithIncludeAndTrackingAsync(request.UserId, includeActuals: true, 
            includeStories: true, includeFollowers: true, includeFollowings: true);

        var userPosts = await postRepository.GetPostsByUserIdWithInclude(request.UserId, includeLikes: true, includeComments: true);

        if (foundUser is null) return ValueResult<UserDetailedResponse>.Failure(UserErrors.UserNotFound);

        var mappedUser = mapper.Map<UserDetailedResponse>(foundUser);
        var mappedUserPosts = mapper.Map<List<ProfilePostResponse>>(userPosts);

        mappedUser.FollowersCount = foundUser.Followers.Count;
        mappedUser.FollowingsCount = foundUser.Followings.Count;
        mappedUser.Posts = mappedUserPosts;

        return ValueResult<UserDetailedResponse>.Success(mappedUser);
    }
}

