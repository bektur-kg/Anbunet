namespace Anbunet.Application.Features.Users.UpdateProfilePicture;

public record UpdateProfilePictureUserCommand(IFormFile File) : ICommand<Result>;