using Anbunet.Domain.Modules.Users;

namespace Anbunet.Domain.Modules.Chats;

public class Chat : Entity
{
    public List<User> Users { get; set; }
    public List<Message> Messages { get; set; }
}
