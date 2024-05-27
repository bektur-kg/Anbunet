using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Follows;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Follows.GetFollowers;

public record GetUserFollowersCommand(long userId) : ICommand<ValueResult<List<FollowResponse>>>;
