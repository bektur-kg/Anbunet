namespace Anbunet.Application.Contracts.Stories;

public record FollowingStoriesResponse
{
    public long Id { get; set; }

    public required string Login { get; set; }

    public string? ProfilePicture { get; set; }

    public List<ProfileStoryResponse> Stories { get; set; }
}