namespace Anbunet.Application.Features.Actuals.CreateActuals;

public record CreateActualsCommmand(CreateActualRequest Data) : ICommand<Result>;