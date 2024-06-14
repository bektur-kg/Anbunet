namespace Anbunet.Application.Features.Actuals.Delete;

public record DeleteActualCommand(long ActualId) : ICommand<Result>;

