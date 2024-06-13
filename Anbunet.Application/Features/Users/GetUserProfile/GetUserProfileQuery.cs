namespace Anbunet.Application.Features.Users.GetUserProfile;

public record GetUserProfileQuery(long UserId) : IQuery<ValueResult<UserDetailedResponse>>;