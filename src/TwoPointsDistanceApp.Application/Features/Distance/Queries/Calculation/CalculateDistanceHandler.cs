using TwoPointsDistanceApp.Application.Common.CQRS;
using TwoPointsDistanceApp.Application.Common.DistanceCalculation;
using TwoPointsDistanceApp.Domain.ValueObjects;

namespace TwoPointsDistanceApp.Application.Features.Distance.Queries.Calculation;

public class CalculateDistanceHandler : IQueryHandler<CalculateDistance, LengthUnit>
{
    private readonly IEnumerable<IDistanceCalculator> _distanceCalculators;

    public CalculateDistanceHandler(IEnumerable<IDistanceCalculator> distanceCalculators)
    {
        _distanceCalculators = distanceCalculators;
    }

    public ValueTask<LengthUnit> HandleAsync(CalculateDistance query, CancellationToken ct)
    {
        var distanceCalculator = _distanceCalculators.First();

        return ValueTask.FromResult(distanceCalculator.Calculate(query.PointA, query.PointB));
    }
}