using TwoPointsDistanceApp.Application.Common.CQRS;
using TwoPointsDistanceApp.Application.Common.DistanceCalculators;
using TwoPointsDistanceApp.Application.Features.Distance.Queries.DTOs;
using TwoPointsDistanceApp.Application.Features.Distance.Queries.DTOs.Extensions;

namespace TwoPointsDistanceApp.Application.Features.Distance.Queries.Calculation;

public class CalculateDistanceHandler : IQueryHandler<CalculateDistance, LengthUnitDto>
{
    private readonly IEnumerable<IDistanceCalculator> _distanceCalculators;

    public CalculateDistanceHandler(IEnumerable<IDistanceCalculator> distanceCalculators)
    {
        _distanceCalculators = distanceCalculators;
    }

    public ValueTask<LengthUnitDto> HandleAsync(CalculateDistance query, CancellationToken ct)
    {
        var distanceCalculator = _distanceCalculators.FirstOrDefault(calculator => calculator.IsMatchFor(query.Formula));
        distanceCalculator ??= _distanceCalculators.First();

        var lengthUnit = distanceCalculator.Calculate(query.PointA, query.PointB);
        return ValueTask.FromResult(lengthUnit.ToApiContract());
    }
}