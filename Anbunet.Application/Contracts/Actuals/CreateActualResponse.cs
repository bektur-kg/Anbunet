namespace Anbunet.Application.Contracts.Actuals;

public record CreateActualResponse
{
    public long Id { get; set; }

    public required string Name { get; set; }
}

