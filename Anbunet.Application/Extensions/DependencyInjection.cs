using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Anbunet.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        return services
            .AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}

