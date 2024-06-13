namespace Anbunet.Application.Features.Users.UpdatePassword;

public record UpdatePasswordUserCommand(UserUpdatePasswordRequest Data) : ICommand<Result>;