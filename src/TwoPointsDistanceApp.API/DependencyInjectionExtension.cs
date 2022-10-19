using TwoPointsDistanceApp.Application.Common.CQRS;
using TwoPointsDistanceApp.Middlewares;

namespace TwoPointsDistanceApp;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApi(this IServiceCollection services)
        => services.AddCqrsDispatchers();

    public static IApplicationBuilder UseApi(this IApplicationBuilder app)
        => app.UseExceptionMiddleware();

    private static IServiceCollection AddCqrsDispatchers(this IServiceCollection services)
    {
        services.AddTransient<IQueryDispatcher, QueryDispatcher>();

        return services;
    }

    private static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app) => app.UseMiddleware<ExceptionMiddleware>();
}