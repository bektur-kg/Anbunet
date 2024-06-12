using Anbunet.Application.Contracts.Chats;
using Anbunet.Application.Contracts.Comments;
using Anbunet.Domain.Modules.Chats;
using Anbunet.Domain.Modules.Comments;
using AutoMapper;

namespace Anbunet.Application.Features.Chats;

public class ChatMappings : Profile
{
    public ChatMappings() 
    {
        CreateMap<Chat, ChatResponse>();

    }
}
