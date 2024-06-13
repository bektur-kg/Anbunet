namespace Anbunet.Application.Features.Users.Update;

public record UpdateUserCommand(UpdateUserRequest Data) : ICommand<Result>;
