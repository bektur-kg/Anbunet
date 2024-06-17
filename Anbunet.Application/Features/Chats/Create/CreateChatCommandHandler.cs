using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Chats;
using Anbunet.Application.Features.Comments.CreateComment;
using Anbunet.Application.Features.Posts;
using Anbunet.Application.Features.Users;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Chats;
using Anbunet.Domain.Modules.Comments;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Domain.Modules.Users;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Chats.Create;

public class CreateChatCommandHandler
    (
        IHttpContextAccessor httpContextAccessor,
        IChatRepository chatRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<CreateChatCommand, ValueResult<CreateChatResponse>>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<ValueResult<CreateChatResponse>> Handle(CreateChatCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var currentUser = await userRepository.GetByIdAsyncAndTracking(currentUserId);
        var foundUser = await userRepository.GetByIdAsyncAndTracking(request.userId);
        if (foundUser == null) return ValueResult<CreateChatResponse>.Failure(UserErrors.UserNotFound);

        Chat chat = new Chat
        {
            Users = new List<User> { currentUser, foundUser }
        };

        chatRepository.Add(chat);
        await unitOfWork.SaveChangesAsync();
        CreateChatResponse response = new CreateChatResponse()
        {
            ChatId = chat.Id,
        };
        return ValueResult<CreateChatResponse>.Success(response);

    }
}