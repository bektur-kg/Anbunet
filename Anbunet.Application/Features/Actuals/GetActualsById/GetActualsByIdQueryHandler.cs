using Anbunet.Application.Contracts.Actuals;
using Anbunet.Application.Abstractions;
using Anbunet.Domain.Modules.Actuals;
using Anbunet.Domain.Abstractions;
using AutoMapper;

namespace Anbunet.Application.Features.Actuals.GetActualsById;

public class GetActualsByIdQueryHandler(
        IActualRepository actualRepository,
        IMapper _mapper
    ) : IQueryHandler<GetActualsByIdQuery, ValueResult<ProfileActualResponse>>
{
    public async Task<ValueResult<ProfileActualResponse>> Handle(GetActualsByIdQuery request, CancellationToken cancellationToken)
    {
        var actual = await actualRepository.GetByIdWithInclude(request.ActualId, includeStories: true);
        if (actual == null) return ValueResult<ProfileActualResponse>.Failure(ActualErrors.ActualNotFound);

        var mappedActual = _mapper.Map<ProfileActualResponse>(actual);

        return ValueResult<ProfileActualResponse>.Success(mappedActual);
    }
}