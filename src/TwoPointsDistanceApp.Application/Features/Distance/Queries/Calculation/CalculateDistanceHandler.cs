using TwoPointsDistanceApp.Application.Common.CQRS;

namespace TwoPointsDistanceApp.Application.Features.Distance.Queries.Calculation;

public class CalculateDistanceHandler : IQueryHandler<CalculateDistance, double>
{
    public ValueTask<double> HandleAsync(CalculateDistance query, CancellationToken ct)
    {
        return ValueTask.FromResult(0d);
    }
}