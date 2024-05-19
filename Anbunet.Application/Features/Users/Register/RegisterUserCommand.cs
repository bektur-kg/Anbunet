using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Users;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Users.Register;

public record RegisterUserCommand(RegisterUserRequest Data) : ICommand<Result>;

