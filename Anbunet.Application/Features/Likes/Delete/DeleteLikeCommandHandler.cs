using Anbunet.Application.Abstractions;
using Anbunet.Application.Features.Posts;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Likes.Delete;

public class DeleteLikeCommandHandler(
        IPostRepository postRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
    : ICommandHandler<DeleteLikeCommand, Result>
{
    public readonly HttpContext _httpContext = httpContextAccessor.HttpContext;

    public async Task<Result> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
    {
        var foundPost = await postRepository.GetByIdWithIncludeAndTracking(request.PostId, includeLikes: true);
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        if (foundPost is null) return Result.Failure(PostErrors.PostNotFound);

        var userLike = foundPost.Likes.FirstOrDefault(like => like.UserId == userId);

        if (userLike==null) return Result.Failure(PostErrors.UserDidNotLikeIt);

        foundPost.Likes.Remove(userLike);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
