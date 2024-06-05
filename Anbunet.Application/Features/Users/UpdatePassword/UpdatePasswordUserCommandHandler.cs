using Anbunet.Application.Abstractions;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Users;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Users.UpdatePassword;

public class UpdatePasswordUserCommandHandler(
        IUserRepository _userRepository,
        IPasswordManager _passwordManager,
        IUnitOfWork _unitOfWork,
        IHttpContextAccessor _httpContextAccessor,
        IFileProvider _fileProvider)
        : ICommandHandler<UpdatePasswordUserCommand, Result>
{
    private readonly HttpContext httpContext = _httpContextAccessor.HttpContext;
    public async Task<Result> Handle(UpdatePasswordUserCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var user = await _userRepository.GetByIdAsync(userId);

        var isPasswordVerified = _passwordManager.Verify(request.Data.OldPassword, user.PasswordHash);

        if (!isPasswordVerified)
        {
            return Result.Failure(UserErrors.OldPasswordIsIncorrect);
        }

        var hashedPassword = _passwordManager.Hash(request.Data.NewPassword);

        user.PasswordHash = hashedPassword;

        _userRepository.Update(user);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
