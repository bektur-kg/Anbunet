namespace Anbunet.Application.Contracts.Chats;

public class MessageToUserRequest
{
    public string PrivateChatId { get; set; }
    public string Message { get; set; }
}
