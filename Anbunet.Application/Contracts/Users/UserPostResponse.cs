namespace Anbunet.Application.Contracts.Users;

public record UserPostResponse
{
    public long Id { get; set; }

    public required string Login { get; set; }

    public string? ProfilePicture { get; set; }
}