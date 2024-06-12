using Anbunet.Domain.Modules.Chats;

namespace Anbunet.Application.Contracts.Chats;

public record ChatResponse
{
    public UserChatResponse User { get; set; }

    public List<MessageResponse> Messages { get; set; }

}
