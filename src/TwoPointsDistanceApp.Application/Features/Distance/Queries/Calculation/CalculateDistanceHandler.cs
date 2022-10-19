using TwoPointsDistanceApp.Application.Common.CQRS;
using TwoPointsDistanceApp.Application.Common.DistanceCalculation;
using TwoPointsDistanceApp.Domain.ValueObjects;

namespace TwoPointsDistanceApp.Application.Features.Distance.Queries.Calculation;

public class CalculateDistanceHandler : IQueryHandler<CalculateDistance, LengthUnit>
{
    private readonly IDistanceCalculator _distanceCalculator;

    public CalculateDistanceHandler(IDistanceCalculator distanceCalculator)
    {
        _distanceCalculator = distanceCalculator;
    }

    public ValueTask<LengthUnit> HandleAsync(CalculateDistance query, CancellationToken ct)
    {
        return ValueTask.FromResult(_distanceCalculator.Calculate(query.PointA, query.PointB));
    }
}