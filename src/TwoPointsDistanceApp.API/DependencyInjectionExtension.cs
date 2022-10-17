using TwoPointsDistanceApp.Application.Common.CQRS;

namespace TwoPointsDistanceApp;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApi(this IServiceCollection services)
        => services.AddCqrsDispatchers();

    private static IServiceCollection AddCqrsDispatchers(this IServiceCollection services)
    {
        services.AddTransient<IQueryDispatcher, QueryDispatcher>();

        return services;
    }
}