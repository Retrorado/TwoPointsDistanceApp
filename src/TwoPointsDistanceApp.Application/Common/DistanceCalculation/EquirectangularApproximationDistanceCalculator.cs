using TwoPointsDistanceApp.Application.Features.Distance.Queries.DTOs;
using TwoPointsDistanceApp.Domain.Constants;
using TwoPointsDistanceApp.Domain.ValueObjects;

namespace TwoPointsDistanceApp.Application.Common.DistanceCalculation;

/// <summary>
/// Formula:
/// x = Δλ ⋅ cos φm
/// y = Δφ
/// d = R ⋅ √x² + y²
/// </summary>
public class EquirectangularApproximationDistanceCalculator : IDistanceCalculator
{
    private const DistanceCalculationFormula Formula = DistanceCalculationFormula.EquirectangularApproximation;
    
    public LengthUnit Calculate(Coordinates pointA, Coordinates pointB)
    {
        if (pointA == pointB) return LengthUnit.Zero;

        var sumLatitude = pointA.Latitude + pointB.Latitude;
        var deltaLatitude = (pointB.Latitude - pointA.Latitude).ToRadians();
        var deltaLongitude = (pointB.Longitude - pointA.Longitude).ToRadians();

        var x = deltaLongitude.Value * Math.Cos(sumLatitude.Value / 2);
        var y = deltaLatitude.Value;

        var distance = Math.Sqrt(x * x + y * y) * EarthConstants.RadiusInMeters;

        return LengthUnit.FromMeters(distance);
    }

    public bool IsMatchFor(DistanceCalculationFormula formula) => Formula == formula;
}