using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Users;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Users.GetCurrentUserProfile;

public record GetCurrentUserProfileQuery() : IQuery<ValueResult<UserDetailedResponse>>;

