namespace Anbunet.Application.Features.Chats;

public abstract class ChatErrors
{
    public static Error SenderNotFound = new("Sender.SenderNotFound", "Sender is not found");
}