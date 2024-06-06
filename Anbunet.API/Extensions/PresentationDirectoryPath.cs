namespace Anbunet.Application.Extensions;

public class PresentationDirectoryPath : IPresentationDirectoryPath
{
    public string Get() => Directory.GetCurrentDirectory();
}