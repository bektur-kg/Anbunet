namespace Anbunet.Application.Features.Comments.Delete;

public class DeleteCommentCommandHandler
    (
        ICommentRepository commentRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
    : ICommandHandler<DeleteCommentCommand, Result>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;
    public async Task<Result> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var foundComment = await commentRepository.GetByIdAsync(request.CommentId);
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        if (foundComment is null) return Result.Failure(CommentErrors.CommentNotFound);
        if (userId != foundComment.UserId) return Result.Failure(CommentErrors.CannotDeleteThisComment);

        commentRepository.Remove(foundComment);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}