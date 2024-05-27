using Anbunet.Application.Abstractions;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Comments;
using Anbunet.Domain.Modules.Posts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Comments.CreateComment;

public class CreateCommentCommandHandler
    (
        ICommentRepository commentRepository,
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<CreateCommentCommand, Result>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var newComment = new Comment()
        {
            UserId = userId,
            PostId = request.Data.PostId,
            Text = request.Data.Text
        };

        commentRepository.Add(newComment);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}