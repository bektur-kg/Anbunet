﻿using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Follows;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Follows.GetFollowings;

public record GetUserFollowingsQuery(long userId) : ICommand<ValueResult<List<FollowResponse>>>;