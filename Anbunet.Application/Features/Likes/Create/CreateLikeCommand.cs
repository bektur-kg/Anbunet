using Anbunet.Application.Abstractions;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Likes.Create;

public record CreateLikeCommand(long PostId) : ICommand<Result>;

