using Anbunet.Application.Contracts.Chats;
using Anbunet.Domain.Modules.Chats;

namespace Anbunet.Application.Features.Chats;

public class ChatMappings : Profile
{
    public ChatMappings() 
    {
        CreateMap<Chat, ContactResponse>();

    }
}