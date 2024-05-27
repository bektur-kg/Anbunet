using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Likes;
using Anbunet.Application.Contracts.Users;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Likes.GetAll;

public record GetAllLikeCommand(long PostId) : ICommand<ValueResult<List<LikeResponse>>>;
