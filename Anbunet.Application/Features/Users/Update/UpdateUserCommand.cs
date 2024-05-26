using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Users;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Users.Update;

public record UpdateUserCommand(UpdateUserRequest Data) : ICommand<Result>;
