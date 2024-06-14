namespace Anbunet.Application.Features.Follows.CreateFollowers;

public class CreateFollowingCommandHandler
(
        IUserRepository userRepository,
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<CreateFollowingCommand, Result>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(CreateFollowingCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var currentUser = await userRepository.GetByIdAsync(userId);

        if (userId == request.UserId) return Result.Failure(FollowErrors.CurrentUserCantFollowToHimself);
                
        var user = await userRepository.GetByIdWithIncludeAndTrackingAsync(request.UserId, includeFollowers: true);
        if (user == null || currentUser == null) return Result.Failure(UserErrors.UserNotFound);

        if (user.Followers.Any(u => u.Id == userId)) return Result.Failure(FollowErrors.FollowerIsAlreadySubscribe);

        user.Followers.Add(currentUser);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}