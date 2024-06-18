namespace Anbunet.Application.Features.Actuals.Update;

public record UpdateActualCommand(long ActualId, UpdateActualRequest Data) : ICommand<Result>;