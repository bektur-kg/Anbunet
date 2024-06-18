namespace Anbunet.Application.Features.Posts.Create;

public class CreatePostCommandHandler
    (
        IPostRepository postRepository,
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork,
        IFileProvider fileProvider
    )
    : ICommandHandler<CreatePostCommand, Result>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var result = await fileProvider.CreateAsync(request.Data.File, cancellationToken);

        if(!result.IsSuccess) return Result.Failure(result.Error);

        var newPost = new Post
        {
            UserId = userId,
            MediaUrl = result.Value,
            Description = request.Data.Description
        };

        postRepository.Add(newPost);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}