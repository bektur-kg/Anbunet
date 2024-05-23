using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Posts;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Posts.Create;

public record CreatePostCommand(PostCreateRequest Data) : ICommand<Result>;

