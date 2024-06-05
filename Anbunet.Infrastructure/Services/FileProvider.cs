using Anbunet.Application.Features.Posts;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Anbunet.Infrastructure.Services;

public class FileProvider
    (
        IPresentationDirectoryPath directoryPath
    ) : IFileProvider
{

    public async Task<ValueResult<string>> Create(IFormFile file, CancellationToken cancellationToken)
    {
        var directory = directoryPath.Get();
        var extensions = new string[]
        {
            ".jpg", ".mp4", ".jpeg", ".png",
        };

        var fileExtension = Path.GetExtension(file.FileName);

        if (!extensions.Contains(fileExtension)) return ValueResult<string>.Failure(PostErrors.NotSupportedFileExtensions);

        var size = file.Length;

        if (size > 1024 * 1024 * 20) return ValueResult<string>.Failure(PostErrors.NotSupportedFileSize);

        var fileName = Guid.NewGuid().ToString() + fileExtension;
        var path = Path.Combine(directory, "wwwroot");
        using FileStream stream = new(Path.Combine(path, fileName), FileMode.Create);
        await file.CopyToAsync(stream, cancellationToken);
        var mediaUrl = Path.Combine("https://localhost:7199/" + fileName);

        return ValueResult<string>.Success(mediaUrl);
    }

    public async Task<Result> Delete(string fileName)
    {
        var directory = directoryPath.Get();
        var path = Path.Combine(directory, "wwwroot", "https://localhost:7199/" + fileName);

        if (!File.Exists(path))
            return Result.Failure(PostErrors.FileNotFound);

        File.Delete(path);
        return Result.Success();
    }
}

