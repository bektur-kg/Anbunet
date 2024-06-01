using Anbunet.Application.Abstractions;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

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
        var post = await postRepository.GetByIdWithInclude(request.Id);

        if (post == null) return Result.Failure(PostErrors.PostNotFound);

        if (post.UserId != userId) return Result.Failure(PostErrors.ThisIsNotPostOfThisUser);

        await fileProvider.Delete(post.MediaUrl);
        postRepository.Remove(post);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}