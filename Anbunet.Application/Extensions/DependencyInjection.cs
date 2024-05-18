using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Anbunet.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}

