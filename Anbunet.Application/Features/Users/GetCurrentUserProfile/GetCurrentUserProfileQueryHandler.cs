using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Posts;
using Anbunet.Application.Contracts.Users;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Domain.Modules.Users;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Users.GetCurrentUserProfile;

public class GetCurrentUserProfileQueryHandler
    (
        IUserRepository userRepository,
        IPostRepository postRepository,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor
    )
    : IQueryHandler<GetCurrentUserProfileQuery, ValueResult<UserDetailedResponse>>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;

    public async Task<ValueResult<UserDetailedResponse>> Handle(GetCurrentUserProfileQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var foundUser = await userRepository.GetByIdWithIncludeAsync(currentUserId, includeActuals: true,
            includeStories: true, includeFollowers: true, includeFollowings: true);

        var userPosts = await postRepository.GetPostsByUserIdWithInclude(currentUserId, includeLikes: true, includeComments: true);

        if (foundUser is null) return ValueResult<UserDetailedResponse>.Failure(UserErrors.UserNotFound);

        var mappedUser = mapper.Map<UserDetailedResponse>(foundUser);
        var mappedUserPosts = mapper.Map<List<ProfilePostResponse>>(userPosts);

        mappedUser.FollowersCount = foundUser.Followers.Count;
        mappedUser.FollowingsCount = foundUser.Followings.Count;
        mappedUser.Posts = mappedUserPosts;

        return ValueResult<UserDetailedResponse>.Success(mappedUser);
    }
}

