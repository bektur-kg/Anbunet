using Anbunet.Application.Abstractions;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Actuals.Delete;

public record DeleteActualCommand(long acrualId) : ICommand<Result>;

