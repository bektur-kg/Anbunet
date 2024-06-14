namespace Anbunet.Application.Features.Users.UpdateProfilePicture;

public class UpdateProfilePictureUserCommandHandler
    (
        IUserRepository _userRepository,
        IUnitOfWork _unitOfWork,
        IHttpContextAccessor _httpContextAccessor,
        IFileProvider _fileProvider
    )
    : ICommandHandler<UpdateProfilePictureUserCommand, Result>
{
    HttpContext httpContext = _httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(UpdateProfilePictureUserCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var user = await _userRepository.GetByIdAsync(userId);

        var mediaUrl = user.ProfilePicture;
        if ( mediaUrl != null ) await _fileProvider.DeleteAsync(mediaUrl);

        var result = await _fileProvider.CreateAsync(request.File, cancellationToken);

        if (!result.IsSuccess) return Result.Failure(result.Error);

        user.ProfilePicture = result.Value;

        _userRepository.Update(user);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
