using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Chats;
using Anbunet.Application.Contracts.Comments;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Chats.GetChats;

public record GetChatsQuery() : IQuery<ValueResult<List<ChatResponse>>>;