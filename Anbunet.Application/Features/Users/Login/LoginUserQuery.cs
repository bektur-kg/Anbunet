using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Users;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Users.Login;

public record LoginUserQuery(LoginUserRequest Data) : IQuery<ValueResult<string>>;

