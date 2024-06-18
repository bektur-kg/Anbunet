namespace Anbunet.Application.Features.Actuals.CreateActuals;

public class CreateActualsCommmandHandler
(
        IActualRepository actualRepository,
        IUserRepository userRepository,
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    : ICommandHandler<CreateActualsCommmand, ValueResult<CreateActualResponse>>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<ValueResult<CreateActualResponse>> Handle(CreateActualsCommmand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var user = await userRepository.GetByIdWithIncludeAsync(userId);
        if (user == null) return ValueResult<CreateActualResponse>.Failure(UserErrors.UserNotFound);

        var actual = new Actual()
        {
            UserId = userId,
            Name = request.Data.Name
        };

        actualRepository.Add(actual);
        await unitOfWork.SaveChangesAsync();

        var mappedActual = mapper.Map<CreateActualResponse>(actual);

        return ValueResult<CreateActualResponse>.Success(mappedActual);
    }
}