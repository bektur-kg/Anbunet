using Anbunet.Domain.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Anbunet.Application.Services;

public interface IFileProvider
{
    Task<ValueResult<string>> Create(IFormFile file, CancellationToken cancellationToken);

    Task<ValueResult<string>> Delete(string fileName);
}
