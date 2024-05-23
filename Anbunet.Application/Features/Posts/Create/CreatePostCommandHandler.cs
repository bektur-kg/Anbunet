using Anbunet.Application.Abstractions;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Posts.Create;

public class CreatePostCommandHandler
    (
        IPostRepository postRepository,
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork,
        IPresentationDirectoryPath directoryPath
    )
    : ICommandHandler<CreatePostCommand, Result>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var directory = directoryPath.Get();
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var file = request.Data.File;
        var extensions = new string[]
        {
            ".jpg", ".mp4", ".jpeg", ".png",
        };
        var fileExtension = Path.GetExtension(file.FileName);

        if (!extensions.Contains(fileExtension)) return Result.Failure(PostErrors.NotSupportedFileExtensions);

        var size = file.Length;

        if (size > 1024 * 1024 * 20) return Result.Failure(PostErrors.NotSupportedFileSize);

        var fileName = Guid.NewGuid().ToString() + fileExtension;
        var path = Path.Combine(directory, "wwwroot");
        using FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
        await file.CopyToAsync(stream, cancellationToken);

        var mediaUrl = Path.Combine("https://localhost:7199/", fileName);

        var newPost = new Post
        {
            UserId = userId,
            MediaUrl = mediaUrl,
            Description = request.Data.Description
        };

        postRepository.Add(newPost);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

