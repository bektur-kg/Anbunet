using Anbunet.Domain.Modules.Users;

namespace Anbunet.Domain.Modules.Chats;

public class Message : Entity
{
    public long SenderId { get; set; }

    public long RecipientId { get; set; }
    public DateTime DateTime { get; set; }

    public string Text { get; set; }

    public long ChatId { get; set; }

    public Chat Chat { get; set; }

    public List<User> Users { get; set; }
}
