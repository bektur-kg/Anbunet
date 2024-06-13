namespace Anbunet.Application.Features.Stories.Delete;

public record DeleteStoryCommand(long Id) : ICommand<Result>;