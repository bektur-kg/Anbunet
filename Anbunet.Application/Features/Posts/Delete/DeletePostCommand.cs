using Anbunet.Application.Abstractions;
using Anbunet.Domain.Abstractions;

namespace Anbunet.Application.Features.Posts.Delete;

public record DeletePostCommand(long Id) : ICommand<Result>;