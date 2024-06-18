namespace Anbunet.Application.Contracts.Chats;

public record UserChatResponse
{
    public long Id { get; set; }
    public required string Login { get; set; }

    public string? ProfilePicture { get; set; }
}