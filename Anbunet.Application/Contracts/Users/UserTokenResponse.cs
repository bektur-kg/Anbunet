namespace Anbunet.Application.Contracts.Users;

public record UserTokenResponse
{
    public required string Token { get; set; }
}