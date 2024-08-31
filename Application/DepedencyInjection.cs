using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DepedencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        return service;
    }
}