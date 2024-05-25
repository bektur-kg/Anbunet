namespace Anbunet.Application.Contracts.Stories;

public class ProfileStoryResponse
{
    public required string MediaUrl { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ExpiryDate { get; set; }
}

