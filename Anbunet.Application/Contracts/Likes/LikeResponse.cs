using Anbunet.Application.Contracts.Users;

namespace Anbunet.Application.Contracts.Likes;

public record LikeResponse
{
    public long Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public UserLikeResponse? User { get; set; }
}

