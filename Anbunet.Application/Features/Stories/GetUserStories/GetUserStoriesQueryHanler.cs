﻿namespace Anbunet.Application.Features.Stories.GetUserStories;

public class GetUserStoriesQueryHanler
    (
        IStoryRepository storyRepository,
        IUserRepository userRepository,
        IMapper mapper
    )
    : IQueryHandler<GetUserStoriesQuery, ValueResult<List<ProfileStoryResponse>>>
{
    public async Task<ValueResult<List<ProfileStoryResponse>>> Handle(GetUserStoriesQuery request, CancellationToken cancellationToken)
    {
        var foundUser = await userRepository.GetByIdAsync(request.UserId);

        if (foundUser is null) return ValueResult<List<ProfileStoryResponse>>.Failure(UserErrors.UserNotFound);

        var stories = await storyRepository.GetStoriesByUserIdAsync(request.UserId);

        var mappedStories = mapper.Map<List<ProfileStoryResponse>>(stories);

        return ValueResult<List<ProfileStoryResponse>>.Success(mappedStories);
    }
}