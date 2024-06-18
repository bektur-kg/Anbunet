using Anbunet.Domain.Modules.Chats;

namespace Anbunet.Application.Contracts.Chats;

public record ContactResponse
{
    public UserChatResponse User { get; set; }
    public long ChatId { get; set; }
    public string? LastMessage { get; set; }
    public DateTime? LastMessageDate { get; set; }

}
