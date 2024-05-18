using Anbunet.Domain.Modules.Users;

namespace Anbunet.Application.Services;

public interface IJwtProvider
{
    string Generate(User user);
}