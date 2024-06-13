namespace Anbunet.Application.Features.Stories;

public abstract class StoriesErrors
{
    public static readonly Error StoriesNotFound = new("Stories.StoriesNotFound", "Stories is not found.");
    public static readonly Error YouCanDeleteOnlyYourStory = new("Stories.YouCanDeleteOnlyYourStory", "You can delete only your story.");
}