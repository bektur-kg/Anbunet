namespace Anbunet.Application.Services;

public interface IFileProvider
{
    Task<ValueResult<string>> CreateAsync(IFormFile file, CancellationToken cancellationToken);

    Task<Result> DeleteAsync(string fileName);
}