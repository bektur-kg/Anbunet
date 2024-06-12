using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Users;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Users.GettingUsersByLogin;

public record GettingUsersByLoginQuery(string? Login) : IQuery<ValueResult<List<UsersSearchResponse>>>;