namespace Anbunet.Application.Features.Actuals.GetUserActuals;

public record GetAllActualsByUserIdQuery(long UserId) : IQuery<ValueResult<List<ProfileActualResponse>>>;