using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Actuals;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Actuals.Update;

public record UpdateActualCommand(UpdateActualRequest Data) : ICommand<Result>;
