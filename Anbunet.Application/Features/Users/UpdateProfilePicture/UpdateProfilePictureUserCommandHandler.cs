using Anbunet.Application.Abstractions;
using Anbunet.Application.Features.Posts;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Posts;
using Anbunet.Domain.Modules.Users;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Users.UpdateProfilePicture;

public class UpdateProfilePictureUserCommandHandler
    (
        IUserRepository _userRepository,
        IUnitOfWork _unitOfWork,
        IHttpContextAccessor _httpContextAccessor,
        IFileProvider _fileProvider,
        IMapper _mapper
    )
    : ICommandHandler<UpdateProfilePictureUserCommand, Result>
{
    HttpContext httpContext = _httpContextAccessor.HttpContext;

    public async Task<Result> Handle(UpdateProfilePictureUserCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var user = await _userRepository.GetByIdAsync(userId);

        var mediaUrl = user.ProfilePicture;
        if ( mediaUrl != null ) await _fileProvider.Delete(mediaUrl);

        var result = await _fileProvider.Create(request.file, cancellationToken);

        if (!result.IsSuccess) return Result.Failure(result.Error);

        user.ProfilePicture = result.Value;


        _userRepository.Update(user);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
