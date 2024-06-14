using Anbunet.Application.Features.Users;
using System.Security.Claims;

namespace Anbunet.Application.Features.Actuals.Delete;

public class DeleteActualCommandHandler(
        IActualRepository actualRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
    : ICommandHandler<DeleteActualCommand, Result>
{
    public readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(DeleteActualCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var user = await userRepository.GetByIdWithIncludeAndTrackingAsync(userId, includeActuals:true);
        if (user == null) return Result.Failure(UserErrors.UserNotFound);

        var actual = await actualRepository.GetByIdWithIncludeAndTrackedAsync(request.ActualId,includeStories:true);
        if (actual == null) return Result.Failure(ActualErrors.ActualNotFound);

        foreach (var story in actual.Stories.ToList())
        {
            actual.Stories.Remove(story);
        }

        var result = user.Actuals.Remove(actual);
        if (!result) return Result.Failure(ActualErrors.ActualNotFound);

        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
