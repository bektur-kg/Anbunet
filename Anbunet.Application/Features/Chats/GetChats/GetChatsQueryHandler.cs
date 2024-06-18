using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Chats;
using Anbunet.Application.Contracts.Comments;
using Anbunet.Application.Features.Comments.GetAllComments;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Chats;
using Anbunet.Domain.Modules.Comments;
using Anbunet.Domain.Modules.Users;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Xml.Linq;

namespace Anbunet.Application.Features.Chats.GetChats;

public class GetChatsQueryHandler(
        IChatRepository chatRepository,
        IUserRepository userRepository,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper
    ) : IQueryHandler<GetChatsQuery, ValueResult<List<ContactResponse>>>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;

    public async Task<ValueResult<List<ContactResponse>>> Handle(GetChatsQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var foundUser = await userRepository.GetByIdWithIncludeAsync(currentUserId, includeChats: true);

        var chats = foundUser.Chats.ToList();

        List<ContactResponse> resultChats = new List<ContactResponse>() { };

        foreach (var chat in chats)
        {
            var item = await chatRepository.GetByIdWithIncludeAndTrackingAsync(chat.Id, includeMessage: true, includeUsers: true);

            var resultChat = mapper.Map<ContactResponse>(item);
            if (item.Users.FirstOrDefault().Id == currentUserId)
            {
                resultChat.User = mapper.Map<UserChatResponse>(item.Users.LastOrDefault());
            }
            else
            {
                resultChat.User = mapper.Map<UserChatResponse>(item.Users.FirstOrDefault());
            }
            resultChats.Add(resultChat);
        }
        if (resultChats.Count == 0) return ValueResult<List<ContactResponse>>.Success([]);

        return ValueResult<List<ContactResponse>>.Success(resultChats);
    }
}