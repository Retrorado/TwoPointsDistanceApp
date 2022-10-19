using TwoPointsDistanceApp.Application.Features.Distance.Queries.DTOs;
using TwoPointsDistanceApp.Domain.Constants;
using TwoPointsDistanceApp.Domain.ValueObjects;

namespace TwoPointsDistanceApp.Application.Common.DistanceCalculators;

/// <summary>
/// a = sin²(Δφ/2) + cos φ1 ⋅ cos φ2 ⋅ sin²(Δλ/2)
/// c = 2 ⋅ atan2( √a, √(1−a) )
/// d = R ⋅ c
/// </summary>
public class HaversineDistanceCalculator : IDistanceCalculator
{
    private const DistanceCalculationFormula Formula = DistanceCalculationFormula.Haversine;

    public LengthUnit Calculate(Coordinates pointA, Coordinates pointB)
    {
        if (pointA == pointB) return LengthUnit.Zero;

        var phiA = pointA.Latitude.ToRadians();
        var phiB = pointB.Latitude.ToRadians();
        var deltaLatitude = (pointB.Latitude - pointA.Latitude).ToRadians();
        var deltaLongitude = (pointB.Longitude - pointA.Longitude).ToRadians();

        var a = Math.Sin(deltaLatitude.Value / 2) * Math.Sin(deltaLatitude.Value / 2)
                + Math.Cos(phiA.Value) * Math.Cos(phiB.Value) * Math.Sin(deltaLongitude.Value / 2) * Math.Sin(deltaLongitude.Value / 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        var distance = EarthConstants.RadiusInMeters * c;

        return LengthUnit.FromMeters(distance);
    }

    public bool IsMatchFor(DistanceCalculationFormula formula) => Formula == formula;
}