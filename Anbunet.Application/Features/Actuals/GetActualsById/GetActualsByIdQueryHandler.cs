namespace Anbunet.Application.Features.Actuals.GetActualsById;

public class GetActualsByIdQueryHandler
    (
        IActualRepository actualRepository,
        IMapper _mapper
    ) : IQueryHandler<GetActualsByIdQuery, ValueResult<ProfileActualResponse>>
{
    public async Task<ValueResult<ProfileActualResponse>> Handle(GetActualsByIdQuery request, CancellationToken cancellationToken)
    {
        var actual = await actualRepository.GetByIdWithIncludeAsync(request.ActualId, includeStories: true);
        if (actual == null) return ValueResult<ProfileActualResponse>.Failure(ActualErrors.ActualNotFound);

        var mappedActual = _mapper.Map<ProfileActualResponse>(actual);

        return ValueResult<ProfileActualResponse>.Success(mappedActual);
    }
}