using Anbunet.Application.Abstractions;
using Anbunet.Application.Services;
using Anbunet.Domain.Abstractions;
using Anbunet.Domain.Modules.Users;

namespace Anbunet.Application.Features.Users.Register;

public class RegisterUserCommandHandler
    (
        IPasswordManager passwordManager,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
    )
    : ICommandHandler<RegisterUserCommand, Result>
{
    public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var foundUser = await userRepository.GetByLoginAsync(request.Data.Login);

        if (foundUser != null) return Result.Failure(UserErrors.LoginAlreadyExists);

        var hashedPassword = passwordManager.Hash(request.Data.Password);

        var newUser = new User
        {
            Login = request.Data.Login,
            PasswordHash = hashedPassword
        };

        userRepository.Add(newUser);
        await unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}

