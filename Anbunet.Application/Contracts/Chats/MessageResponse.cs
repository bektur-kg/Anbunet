namespace Anbunet.Application.Contracts.Chats;

public record MessageResponse
{
    public long SenderId { get; set; }

    public long RecipientId { get; set; }

    public string Text { get; set; }
}
