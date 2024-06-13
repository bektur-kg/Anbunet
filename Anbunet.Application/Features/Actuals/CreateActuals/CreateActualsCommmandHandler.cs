namespace Anbunet.Application.Features.Actuals.CreateActuals;

public class CreateActualsCommmandHandler
(
        IActualRepository actualRepository,
        IUserRepository userRepository,
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<CreateActualsCommmand, Result>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(CreateActualsCommmand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var user = await userRepository.GetByIdWithIncludeAsync(userId);
        if (user == null) return Result.Failure(UserErrors.UserNotFound);

        var actual = new Actual()
        {
            UserId = userId,
            Name = request.Data.Name
        };

        actualRepository.AddAsync(actual);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}