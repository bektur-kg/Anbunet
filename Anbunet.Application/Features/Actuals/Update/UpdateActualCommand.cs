namespace Anbunet.Application.Features.Actuals.Update;

public record UpdateActualCommand(UpdateActualRequest Data) : ICommand<Result>;