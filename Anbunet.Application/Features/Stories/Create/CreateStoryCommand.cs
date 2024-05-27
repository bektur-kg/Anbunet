using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Stories;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Stories.Create;

public record CreateStoryCommand(CreateStoryRequest Data) : ICommand<Result>;

