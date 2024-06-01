using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Actuals;

public abstract class ActualErrors
{
    public static readonly Error ActualNotFound = new("Actual.ActualNotFound", "Actual not found.");
}