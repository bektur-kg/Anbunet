namespace Anbunet.Application.Features.Actuals.GetUserActuals;

public class GetAllActualsByUserIdQueryHandler
    (
        IActualRepository actualRepository,
        IUserRepository userRepository,
        IMapper mapper
    )
    : IQueryHandler<GetAllActualsByUserIdQuery, ValueResult<List<ProfileActualResponse>>>
{
    public async Task<ValueResult<List<ProfileActualResponse>>> Handle(GetAllActualsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId);

        if (user == null) return ValueResult<List<ProfileActualResponse>>.Failure(UserErrors.UserNotFound);

        var actuals = await actualRepository.GetActualsByUserIdWithIncludeAsync(request.UserId, includeStories: true);
        var mappedActuals = mapper.Map<List<ProfileActualResponse>>(actuals);

        return ValueResult<List<ProfileActualResponse>>.Success(mappedActuals);
    }
}

