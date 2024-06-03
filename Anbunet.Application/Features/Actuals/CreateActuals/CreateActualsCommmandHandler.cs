using Anbunet.Application.Abstractions;
using Anbunet.Application.Features.Follows.CreateFollowers;
using Anbunet.Application.Features.Users;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Actuals;
using Anbunet.Domain.Modules.Users;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Anbunet.Application.Features.Actuals.CreateActuals;

public class CreateActualsCommmandHandler
(
        IActualRepository actualRepository,
        IUserRepository userRepository,
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork
        //IMapper _mapper
    )
    : ICommandHandler<CreateActualsCommmand, Result>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result> Handle(CreateActualsCommmand request, CancellationToken cancellationToken)
    {
        var userId = long.Parse(_httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var user = await userRepository.GetByIdWithIncludeAsync(userId);
        if (user == null) return Result.Failure(UserErrors.UserNotFound);

        var actual = new Actual()
        {
            UserId = userId,
            Name = request.Data.Name
        };

        user.Actuals.Add(actual);
        actualRepository.Add(actual);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}