using Anbunet.Application.Abstractions;
using Anbunet.Application.Features.Follows.Delete;
using Anbunet.Application.Features.Follows;
using Anbunet.Application.Features.Users;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Users;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Anbunet.Domain.Modules.Actuals;
using Anbunet.Domain.Modules.Stories;
using System.Transactions;

namespace Anbunet.Application.Features.Actuals.Delete;

public class DeleteActualCommandHandler(
        IActualRepository actualRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    )
    : ICommandHandler<DeleteActualCommand, Result>
{
    public readonly HttpContext _httpContext = httpContextAccessor.HttpContext;

    public async Task<Result> Handle(DeleteActualCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var user = await userRepository.GetByIdWithIncludeAndTrackingAsync(userId, includeActuals:true);
        if (user == null) return Result.Failure(UserErrors.UserNotFound);

        var actual = await actualRepository.GetByIdWithIncludeAndTracked(request.acrualId,includeStories:true);
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
