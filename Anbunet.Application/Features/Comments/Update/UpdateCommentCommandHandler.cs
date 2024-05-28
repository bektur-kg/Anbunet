using Anbunet.Application.Abstractions;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Comments;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Comments.Update;

public class UpdateCommentCommandHandler
    (
        ICommentRepository commentRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
    : ICommandHandler<UpdateCommentCommand, Result>
{
    private readonly HttpContext httpContext = httpContextAccessor.HttpContext;

    public async Task<Result> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var comment = await commentRepository.GetByIdWithInclude(request.CommentId);

        if (comment is null) return Result.Failure(CommentErrors.CommentNotFound);

        var isUserCommentAuthor = comment.UserId == userId;

        if (!isUserCommentAuthor) return Result.Failure(CommentErrors.UserIsNotCommentAuthor);

        comment.Text = request.Data.Text;
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

