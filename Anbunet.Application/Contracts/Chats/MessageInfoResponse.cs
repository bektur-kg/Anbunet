namespace Anbunet.Application.Contracts.Chats;

public record MessageInfoResponse
{
    public UserChatResponse User { get; set; }
    public DateTime DateTime { get; set; }

    public string Text { get; set; }

}
