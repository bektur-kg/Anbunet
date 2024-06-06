using Anbunet.Application.Abstractions;
using Anbunet.Application.Features.Users;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Users;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Follows.Delete;

public class DeleteFollowingCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
    : ICommandHandler<DeleteFollowingCommand, Result>
{
    public readonly HttpContext _httpContext = httpContextAccessor.HttpContext;

    public async Task<Result> Handle(DeleteFollowingCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var user = await userRepository.GetByIdWithIncludeAndTrackingAsync(userId, includeFollowings: true);
        if (user == null) return Result.Failure(UserErrors.UserNotFound);

        var following = await userRepository.GetByIdWithIncludeAndTrackingAsync(request.UserId);
        if (following == null) return Result.Failure(UserErrors.UserNotFound);

        var result = user.Followings.Remove(following);
        if (!result) return Result.Failure(FollowErrors.FollowingsNotFound);

        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
