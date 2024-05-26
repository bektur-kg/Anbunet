using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Users;
using Anbunet.Application.Features.Users.Register;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Users;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Users.Update;

public class UpdateUserCommandHandler
    (
        IUserRepository _userRepository,
        IUnitOfWork _unitOfWork,
        IHttpContextAccessor _httpContextAccessor,
        IMapper _mapper
    )
    : ICommandHandler<UpdateUserCommand, Result>
{
    HttpContext httpContext = _httpContextAccessor.HttpContext;
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Data.UserId);
        if (user == null) return Result.Failure(UserErrors.UserNotFound);

        var userId = long.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        if (userId != user.Id) return Result.Failure(UserErrors.UserIdDoesNotMatch);

        _mapper.Map(request,user);

        // Сохранение изменений
        _userRepository.Update(user);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
