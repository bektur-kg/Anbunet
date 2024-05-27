using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Chats;
using Anbunet.Application.Contracts.Posts;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Chats.SendMessageToUser;


public record SendMessageToUserCommand(MessageToUserRequest Data) : ICommand<Result>;
