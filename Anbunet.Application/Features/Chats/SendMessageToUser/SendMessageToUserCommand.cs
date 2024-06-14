using Anbunet.Application.Contracts.Chats;

namespace Anbunet.Application.Features.Chats.SendMessageToUser;

public record SendMessageToUserCommand(MessageToUserRequest Data) : ICommand<Result>;