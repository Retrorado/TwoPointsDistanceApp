using TwoPointsDistanceApp.Application.Common.CQRS;
using TwoPointsDistanceApp.Application.Common.DistanceCalculation;

namespace TwoPointsDistanceApp.Application.Features.Distance.Queries.Calculation;

public class CalculateDistanceHandler : IQueryHandler<CalculateDistance, double>
{
    private readonly IDistanceCalculator _distanceCalculator;

    public CalculateDistanceHandler(IDistanceCalculator distanceCalculator)
    {
        _distanceCalculator = distanceCalculator;
    }

    public ValueTask<double> HandleAsync(CalculateDistance query, CancellationToken ct)
    {
        return ValueTask.FromResult(_distanceCalculator.Calculate(query.Latitude, query.Longitude));
    }
}