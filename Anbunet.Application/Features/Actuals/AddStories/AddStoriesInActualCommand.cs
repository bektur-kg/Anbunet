namespace Anbunet.Application.Features.Actuals.AddStories;

public record AddStoriesInActualCommand(long StoryId, AddStoriesRequest Data) : ICommand<Result>;