namespace Anbunet.Application.Features.Users.Register;

public record RegisterUserCommand(RegisterUserRequest Data) : ICommand<Result>;