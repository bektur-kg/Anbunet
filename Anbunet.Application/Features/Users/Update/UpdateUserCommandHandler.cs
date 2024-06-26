﻿namespace Anbunet.Application.Features.Users.Update;

public class UpdateUserCommandHandler
    (
        IUserRepository _userRepository,
        IUnitOfWork _unitOfWork,
        IHttpContextAccessor _httpContextAccessor,
        IMapper _mapper
    )
    : ICommandHandler<UpdateUserCommand, Result>
{
    private readonly HttpContext httpContext = _httpContextAccessor.HttpContext!;
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null) return Result.Failure(UserErrors.UserNotFound);
        _mapper.Map(request.Data,user);

        _userRepository.Update(user);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}