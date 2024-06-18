using Anbunet.Application.Contracts.Chats;
using Anbunet.Domain.Modules.Chats;

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