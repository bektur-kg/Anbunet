using Anbunet.Application.Abstractions;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Stories.Delete;

public record DeleteStoriesCommand(long Id) : ICommand<Result>;