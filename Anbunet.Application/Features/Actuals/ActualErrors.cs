namespace Anbunet.Application.Features.Actuals;

public abstract class ActualErrors
{
    public static readonly Error ActualNotFound = new("Actual.ActualNotFound", "Actual not found.");
    public static readonly Error ThereIsAlreadySuchStory = new("Actual.ThereIsAlreadySuchStory", "There is already such a story.");
}