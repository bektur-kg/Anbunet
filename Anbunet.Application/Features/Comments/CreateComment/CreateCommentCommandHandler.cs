namespace Anbunet.Application.Features.Comments.CreateComment;

public class CreateCommentCommandHandler
    (
        ICommentRepository commentRepository,
        IPostRepository postRepository,
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<CreateCommentCommand, Result>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var post = await postRepository.GetByIdWithIncludeAsync(request.PostId);

        if (post is null) return Result.Failure(PostErrors.PostNotFound);

        var newComment = new Comment()
        {
            UserId = userId,
            PostId = post.Id,
            Text = request.Data.Text
        };

        post.Comments.Add(newComment);
        commentRepository.Add(newComment);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}