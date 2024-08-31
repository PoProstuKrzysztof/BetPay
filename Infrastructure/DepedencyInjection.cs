using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        return service;
    }
}