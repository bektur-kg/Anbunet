namespace Anbunet.Application.Features.Posts.Create;

public record CreatePostCommand(PostCreateRequest Data) : ICommand<Result>;