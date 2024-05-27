using Anbunet.Application.Abstractions;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Stories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Stories.Create;

public class CreateStoryCommandHandler
    (
        IStoryRepository storyRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        IFileProvider fileProvider
    ) 
    : ICommandHandler<CreateStoryCommand, Result>
{
    private readonly HttpContext httpContext = httpContextAccessor.HttpContext;

    public async Task<Result> Handle(CreateStoryCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var fileResponse = await fileProvider.Create(request.Data.File, cancellationToken);

        if (!fileResponse.IsSuccess) return Result.Failure(fileResponse.Error);

        var newStory = new Story
        {
            MediaUrl = fileResponse.Value!,
            UserId = userId,
        };

        storyRepository.Add(newStory);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

