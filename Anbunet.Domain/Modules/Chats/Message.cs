namespace Anbunet.Domain.Modules.Chats;

public class Message : Entity
{
    public long SenderId { get; set; }

    public long RecipientId { get; set; }

    public string Text { get; set; }

    public long PrivateMessageId { get; set; }

    public PrivateMessage PrivateMessage { get; set; }
}
