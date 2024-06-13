namespace Anbunet.Application.Features.Comments.Update;

public class UpdateCommentCommandHandler
    (
        ICommentRepository commentRepository,
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<UpdateCommentCommand, Result>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;
    
    public async Task<Result> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var comment = await commentRepository.GetByIdWithIncludeAsync(request.CommentId);
        if (comment is null || comment.UserId != userId) return Result.Failure(CommentErrors.CommentNotFound);

        comment.Text = request.Data.Text;

        commentRepository.Update(comment);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}