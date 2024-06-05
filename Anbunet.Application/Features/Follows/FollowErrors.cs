using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Follows;

public abstract class FollowErrors
{
    public static readonly Error FollowersNotFound = new("Followers.FollowersNotFound", "Followers is not found");
    public static readonly Error FollowerIsAlreadySubscribe = new("Followers.FollowerIsAlreadySubscribe", "Follower is already subscribe");
    public static readonly Error FollowingsNotFound = new("Followings.FollowingsNotFound", "Followings is not found");
}