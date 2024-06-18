namespace Anbunet.Application.Features.Actuals.AddStories;

public record AddStoriesInActualCommand(long ActualId, AddStoriesRequest Data) : ICommand<Result>;