namespace Anbunet.Application.Contracts.Follows;

public class FollowRequest
{
    public long Id { get; set; }

    public required string Login { get; set; }

    public string? ProfilePicture { get; set; }
}
