namespace Anbunet.Application.Contracts.Chats;

public record CreateChatRequest
{
    public long UserId { get; set; }
}
