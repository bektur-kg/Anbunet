namespace Anbunet.Application.Features.Chats;

public class ChatMappings : Profile
{
    public ChatMappings() 
    {
        CreateMap<Chat, ContactResponse>();

    }
}