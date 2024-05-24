namespace Anbunet.Application.Contracts.Chats;

public class MessageToUserRequest
{
    public long RecipientId { get; set; }
    public string Message { get; set; }
}
