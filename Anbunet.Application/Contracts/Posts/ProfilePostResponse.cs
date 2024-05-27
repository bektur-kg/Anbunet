namespace Anbunet.Application.Contracts.Posts;

public class ProfilePostResponse
{
    public long Id { get; set; }

    public required string MediaUrl { get; set; }

    public DateTime CreatedDate { get; set; }

    public long CommentsCount { get; set; }

    public long LikesCount { get; set; }
}

