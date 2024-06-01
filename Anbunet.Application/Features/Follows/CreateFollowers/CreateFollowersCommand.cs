using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Follows;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Follows.CreateFollowers;

public record CreateFollowersCommand(FollowCreateRequest Data) : ICommand<Result>;