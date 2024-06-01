namespace Anbunet.Application.Contracts.Follows;

public class FollowResponse
{
    public long Id { get; set; }

    public required string Login { get; set; }

    public string? ProfilePicture { get; set; }
}