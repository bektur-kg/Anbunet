﻿namespace Anbunet.Application.Features.Users.GetCurrentUserProfile;

public class GetCurrentUserProfileQueryHandler
    (
        IUserRepository userRepository,
        IPostRepository postRepository,
        IActualRepository actualRepository,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor
    )
    : IQueryHandler<GetCurrentUserProfileQuery, ValueResult<UserDetailedResponse>>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<ValueResult<UserDetailedResponse>> Handle(GetCurrentUserProfileQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var foundUser = await userRepository.GetByIdWithIncludeAsync(currentUserId, includeActuals: true, includeFollowers: true,
            includeFollowings: true);

        var userPosts = await postRepository.GetPostsByUserIdWithIncludeAsync(currentUserId, includeLikes: true, includeComments: true);
        var userActuals = await actualRepository.GetActualsByUserIdWithIncludeAsync(currentUserId, includeStories: true);

        if (foundUser is null) return ValueResult<UserDetailedResponse>.Failure(UserErrors.UserNotFound);

        var mappedUser = mapper.Map<UserDetailedResponse>(foundUser);
        var mappedUserPosts = mapper.Map<List<ProfilePostResponse>>(userPosts);
        var mappedUserActuals = mapper.Map<List<ProfileActualResponse>>(userActuals);

        mappedUser.FollowersCount = foundUser.Followers.Count;
        mappedUser.FollowingsCount = foundUser.Followings.Count;
        mappedUser.Posts = mappedUserPosts;
        mappedUser.Actuals = mappedUserActuals;


        return ValueResult<UserDetailedResponse>.Success(mappedUser);
    }
}