namespace Anbunet.Application.Features.Stories.Create;

public record CreateStoryCommand(CreateStoryRequest Data) : ICommand<Result>;