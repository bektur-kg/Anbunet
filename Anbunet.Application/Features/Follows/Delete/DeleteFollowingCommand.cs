using Anbunet.Application.Abstractions;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Follows.Delete;

public record DeleteFollowingCommand(long UserId) : ICommand<Result>;
