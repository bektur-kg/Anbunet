namespace Anbunet.Domain.Modules.Chats;

public class PrivateMessage : Entity
{
    public List<string> UserIds { get; set; }
    public List<Message> Messages { get; set; }
}
