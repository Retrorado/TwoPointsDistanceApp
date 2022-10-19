using TwoPointsDistanceApp.Domain.Constants;
using TwoPointsDistanceApp.Domain.ValueObjects;

namespace TwoPointsDistanceApp.Application.Common.DistanceCalculation;

public class HaversineDistanceCalculator : IDistanceCalculator
{
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
}