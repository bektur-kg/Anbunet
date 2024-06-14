namespace Anbunet.Application.Features.Actuals.DeleteStory;

public record DeleteStoriesInActualCommand(DeleteStoriesRequest Data) : ICommand<Result>;