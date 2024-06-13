namespace Anbunet.Application.Features.Posts.Delete;

public class DeletePostCommandHandler
    (
        IPostRepository postRepository,
        IUnitOfWork unitOfWork,
        IFileProvider fileProvider,
        IHttpContextAccessor httpContextAccessor
    )
    : ICommandHandler<DeletePostCommand, Result>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var post = await postRepository.GetByIdWithIncludeAsync(request.Id);

        if (post == null) return Result.Failure(PostErrors.PostNotFound);

        if (post.UserId != userId) return Result.Failure(PostErrors.ThisIsNotPostOfThisUser);

        await fileProvider.DeleteAsync(post.MediaUrl);
        postRepository.Remove(post);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}