using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Posts;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Posts.Update;

public record UpdatePostCommand(long Id, PostUpdateRequest Data) : ICommand<Result>;