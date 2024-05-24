using Anbunet.Application.Abstractions;
using Anbunet.Application.Features.Posts.Create;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Chats.SendMessageToUser;

public class SendMessageToUserCommandHandler
    : ICommandHandler<SendMessageToUserCommand, Result>
{
    public Task<Result> Handle(SendMessageToUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
