using Anbunet.Application.Abstractions;
using Anbunet.Application.Contracts.Follows;
using Anbunet.Application.Features.Follows.GetFollowers;
using Anbunet.Application.Features.Users;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Users;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Follows.CreateFollowers;

public class CreateFollowersCommandHandler
(
        IUserRepository userRepository,
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<CreateFollowersCommand, Result>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(CreateFollowersCommand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var currentUser = await userRepository.GetByIdWithIncludeAsync(userId, includeFollowings: true);

        var user = await userRepository.GetByIdWithIncludeAsync(request.Data.UserId, includeFollowers: true);
        if (user == null || currentUser == null) return Result.Failure(UserErrors.UserNotFound);

        if (user.Followers.Any(u => u.Id == userId)) return Result.Failure(FollowErrors.FollowerIsAlreadySubscribe);

        user.Followers.Add(currentUser);
        currentUser.Followings.Add(user);
        userRepository.Update(user);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}