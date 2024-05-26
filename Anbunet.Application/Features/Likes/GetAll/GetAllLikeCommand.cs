using Anbunet.Application.Abstractions;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Likes.GetAll;

public record GetAllLikeCommand(long PostId) : ICommand<ValueResult<int>>;
