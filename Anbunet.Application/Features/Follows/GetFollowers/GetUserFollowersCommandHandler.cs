﻿using Anbunet.Application.Abstractions;
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
    : ICommandHandler<GetUserFollowersCommand, ValueResult<List<FollowRequest>>>
{
    public async Task<ValueResult<List<FollowRequest>>> Handle(GetUserFollowersCommand request, CancellationToken cancellationToken)
    {
        var foundUser = await userRepository.GetByIdAsync(request.userId);

        if (foundUser is null) return ValueResult<List<FollowRequest>>.Failure(UserErrors.UserNotFound);

        var followers = foundUser.Followers.ToList();

        var result = _mapper.Map<List<FollowRequest>>(followers);

        return ValueResult<List<FollowRequest>>.Success(result);
    }
}
