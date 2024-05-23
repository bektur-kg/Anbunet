using Anbunet.Application.Services;

namespace Anbunet.API.Extensions;

public class PresentationDirectoryPath : IPresentationDirectoryPath
{
    public string Get() => Directory.GetCurrentDirectory();
}