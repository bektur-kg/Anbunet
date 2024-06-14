namespace Anbunet.Application.Features.Actuals.GetActualsById;

public record GetActualsByIdQuery(long ActualId) : IQuery<ValueResult<ProfileActualResponse>>;