using MediatR;

namespace Anbunet.Application.Abstractions;

public interface ICommand<TResponse> : IRequest<TResponse>;

public interface ICommand : IRequest;

