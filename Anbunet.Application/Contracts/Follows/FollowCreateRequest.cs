namespace Anbunet.Application.Contracts.Follows;

public record FollowCreateRequest
{
    [Required]
    public long UserId { get; set; }
}