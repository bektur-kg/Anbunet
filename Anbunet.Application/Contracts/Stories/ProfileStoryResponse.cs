namespace Anbunet.Application.Contracts.Stories;

public class ProfileStoryResponse
{
    public long Id { get; set; }
    public required string MediaUrl { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ExpiryDate { get; set; }
}

