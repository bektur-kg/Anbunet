namespace Anbunet.Application.Contracts.Actuals;

public record GetActualByIdRequest
{
    [Required]
    public long UserId { get; set; }

    [Required]
    public long ActualId { get; set; }
}