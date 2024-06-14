namespace Anbunet.Application.Features.Likes.Create;

public class CreateLikeCommandHandler 
    (
        IPostRepository postRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
    : ICommandHandler<CreateLikeCommand, Result>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
    { 
        var foundPost = await postRepository.GetByIdWithIncludeAndTrackingAsync(request.PostId, includeLikes: true);
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        if (foundPost is null) return Result.Failure(PostErrors.PostNotFound);

        var hasAlreadyLiked = foundPost.Likes.Any(like => like.UserId == userId);

        if (hasAlreadyLiked) return Result.Failure(PostErrors.UserHasAlreadyLiked);

        var newLike = new Like
        {
            UserId = userId
        };

        foundPost.Likes.Add(newLike);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}