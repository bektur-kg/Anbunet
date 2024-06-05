using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Actuals;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Actuals.DeleteStory;

public record DeleteStoriesInActualCommand(DeleteStoriesRequest Data) : ICommand<Result>;
