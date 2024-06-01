using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Actuals;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Actuals.AddStories;

public record AddStoriesInActualCommand(AddStoriesRequest Data) : ICommand<Result>;