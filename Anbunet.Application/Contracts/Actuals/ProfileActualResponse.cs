namespace Anbunet.Application.Contracts.Actuals;

public record ProfileActualResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }

    public List<ActualStoryResponse> Stories { get; set; } = [];
}