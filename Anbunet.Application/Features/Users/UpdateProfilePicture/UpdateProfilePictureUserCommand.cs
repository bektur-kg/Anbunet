using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Users;
using Anbunet.Domain.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Anbunet.Application.Features.Users.UpdateProfilePicture;

public record UpdateProfilePictureUserCommand(IFormFile file) : ICommand<Result>;
