namespace Anbunet.Application.Contracts.Actuals;

public record CreateActualRequest
{
    [Required]
    [MaxLength(ActualAttributeConstants.MAX_NAME_LENGTH)]
    public required string Name { get; set; }
}