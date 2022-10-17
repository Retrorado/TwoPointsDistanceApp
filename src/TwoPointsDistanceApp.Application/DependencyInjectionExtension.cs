using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using TwoPointsDistanceApp.Application.Common.CQRS;
using TwoPointsDistanceApp.Application.Common.DistanceCalculation;

namespace TwoPointsDistanceApp.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services
            .AddServices()
            .AddAllCommandHandlers();

    private static IServiceCollection AddAllCommandHandlers(this IServiceCollection services) =>
        services.Scan((Action<ITypeSourceSelector>)(x =>
            x.FromApplicationDependencies()
                .AddClasses((Action<IImplementationTypeFilter>)(c => c.AssignableTo(typeof(IQueryHandler<,>))))
                .AsImplementedInterfaces()
                .WithTransientLifetime()));

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IDistanceCalculator, DistanceCalculator>();
        return services;
    }
}