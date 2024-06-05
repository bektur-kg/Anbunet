using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Users;
using Anbunet.Domain.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Anbunet.Application.Features.Users.UpdatePassword;

public record UpdatePasswordUserCommand(UserUpdatePasswordRequest Data) : ICommand<Result>;
