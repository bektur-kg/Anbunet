using Anbunet.Application.Abstractions;
using Anbunet.Application.Features.Posts;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Comments;
using Anbunet.Domain.Modules.Posts;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Comments.Delete;

public class DeleteCommentCommandHandler
    (
        ICommentRepository commentRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
    : ICommandHandler<DeleteCommentCommand, Result>
{
    public async Task<Result> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var foundComment = await commentRepository.GetByIdAsync(request.CommentId);

        if (foundComment is null) return Result.Failure(CommentErrors.CommentNotFound);

        commentRepository.Remove(foundComment);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
