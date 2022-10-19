using TwoPointsDistanceApp.Domain.ValueObjects;

namespace TwoPointsDistanceApp.Application.Common.DistanceCalculation;

public class SphericalLawOfCosinesDistanceCalculator : IDistanceCalculator
{
    private const double RadiusInMeters = 6371000;

    public LengthUnit Calculate(Coordinates pointA, Coordinates pointB)
    {
        if (pointA == pointB) return LengthUnit.Zero;

        var phiA = pointA.Latitude.ToRadians();
        var phiB = pointB.Latitude.ToRadians();
        var delta = (pointB.Longitude - pointA.Longitude).ToRadians();

        var distance = Math.Acos(
            (Math.Sin(phiA.Value) * Math.Sin(phiB.Value))
            + (Math.Cos(phiA.Value) * Math.Cos(phiB.Value) * Math.Cos(delta.Value))
        ) * RadiusInMeters;

        return LengthUnit.FromMeters(distance);
    }
}