namespace Anbunet.Application.Contracts.Posts;

public record PostDetailedResponse
{
    public long Id { get; set; }

    public required string MediaUrl { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public UserPostResponse? User { get; set; }

    public List<CommentResponse> Comments { get; set; } = [];

    public List<LikeResponse> Likes { get; set; } = [];
}