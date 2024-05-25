using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Users;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Users.GetUserProfile;

public record GetUserProfileQuery(long UserId) : IQuery<ValueResult<UserDetailedResponse>>;

