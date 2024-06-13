namespace Anbunet.Application.Services;

public interface IJwtProvider
{
    string Generate(User user);
}