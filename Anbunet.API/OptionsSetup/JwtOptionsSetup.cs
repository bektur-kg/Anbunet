using Anbunet.Infrastructure.Modules.Users;
using Microsoft.Extensions.Options;

namespace Anbunet.API.OptionsSetup;

public class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JwtOptions>
{
    private const string SectionName = "JWT";

    public void Configure(JwtOptions options)
    {
        configuration.GetSection(SectionName).Bind(options);
    }
}
