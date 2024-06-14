namespace Anbunet.Application.Contracts.Stories;

public record ActualStoryResponse
{
    public long Id { get; set; }

    public required string MediaUrl { get; set; }

    public DateTime CreatedDate { get; set; }
}