namespace Anbunet.Application.Features.Actuals.DeleteStory;

public record DeleteStoriesInActualCommand(long ActualId, long StoryId) : ICommand<Result>;