namespace Anbunet.Application.Features.Actuals.Update;

public class UpdateActualCommandHandler
    (
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor
    ) : ICommandHandler<UpdateActualCommand, Result>
{
    public readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(UpdateActualCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var user = await userRepository.GetByIdWithIncludeAndTrackingAsync(userId, includeActuals: true);
        if (user == null) return Result.Failure(UserErrors.UserNotFound);

        var actual = user.Actuals.FirstOrDefault(a => a.Id == request.ActualId);
        if (actual == null) return Result.Failure(ActualErrors.ActualNotFound);

        actual.Name = request.Data.Name;

        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}