using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Actuals;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Actuals.CreateActuals;

public record CreateActualsCommmand(CreateActualRequest Data) : ICommand<Result>;