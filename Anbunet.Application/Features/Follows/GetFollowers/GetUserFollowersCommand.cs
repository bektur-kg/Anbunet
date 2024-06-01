using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Follows;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Follows.GetFollowers;

public record GetUserFollowersCommand(long UserId) : ICommand<ValueResult<List<FollowResponse>>>;
