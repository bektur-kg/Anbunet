using Anbunet.Domain.Modules.Stories;
using System.ComponentModel.DataAnnotations;

namespace Anbunet.Application.Contracts.Actuals;

public record ProfileActualResponse
{
    public required string Name { get; set; }

    public List<Story> Stories { get; set; } = [];
}

