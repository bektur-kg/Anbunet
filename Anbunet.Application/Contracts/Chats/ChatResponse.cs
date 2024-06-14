namespace Anbunet.Application.Contracts.Chats;

public record ChatResponse
{
    public string Login {get; set;}
    public long ChatId  { get; set;}
    public List<MessageInfoResponse> Messages { get; set; }


}
