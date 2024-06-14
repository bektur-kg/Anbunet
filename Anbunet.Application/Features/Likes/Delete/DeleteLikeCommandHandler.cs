namespace Anbunet.Application.Features.Likes.Delete;

public class DeleteLikeCommandHandler(
        IPostRepository postRepository,
        ILikeRepository likeRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
    : ICommandHandler<DeleteLikeCommand, Result>
{
    public readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
    {
        var foundPost = await postRepository.GetByIdAsync(request.PostId);
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        if (foundPost is null) return Result.Failure(PostErrors.PostNotFound);

        var likes = await likeRepository.GetPostLikesWithIncludeAsync(request.PostId,includeUser: true);
        var userLike = likes.FirstOrDefault(x=>x.UserId==userId);

        if (userLike==null) return Result.Failure(PostErrors.UserDidNotLikeIt);

        likeRepository.Remove(userLike);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}