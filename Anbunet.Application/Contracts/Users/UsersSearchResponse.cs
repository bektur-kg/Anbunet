namespace Anbunet.Application.Contracts.Users;

public record UsersSearchResponse
{
    public long Id { get; set; }

    public required string Login { get; set; }

    public string? ProfilePicture { get; set; }
}