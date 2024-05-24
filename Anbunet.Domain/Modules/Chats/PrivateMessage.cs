using Anbunet.Domain.Abstractions;

namespace Anbunet.Domain.Modules.Chats;

public class PrivateMessage : Entity
{
    public List<Message> Messages { get; set; }
}
