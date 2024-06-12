using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Comments;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Chats.Create;

public record CreateChatCommand(long userId) : ICommand<Result>;