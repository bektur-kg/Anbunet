using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Actuals;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Actuals;
using Anbunet.Domain.Modules.Users;
namespace Anbunet.Application.Features.Actuals.GetActualsById;

public record GetActualsByIdQuery(long ActualId) : IQuery<ValueResult<ProfileActualResponse>>;