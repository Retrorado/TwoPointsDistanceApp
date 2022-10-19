using TwoPointsDistanceApp.Domain.ValueObjects;

namespace TwoPointsDistanceApp.Application.Common.DistanceCalculation;

public class SphericalLawOfCosinesDistanceCalculator : IDistanceCalculator
{
    private const double RadiusInMeters = 6371000;

    public double Calculate(Coordinates pointA, Coordinates pointB)
    {
        if (pointA == pointB) return 0;

        var phiA = Degrees.Create(pointA.Latitude).ToRadians();
        var phiB = Degrees.Create(pointB.Latitude).ToRadians();
        var delta = Degrees.Create(pointB.Longitude - pointA.Longitude).ToRadians();

        var distance = Math.Acos(
            (Math.Sin(phiA.Value) * Math.Sin(phiB.Value))
            + (Math.Cos(phiA.Value) * Math.Cos(phiB.Value) * Math.Cos(delta.Value))
        ) * RadiusInMeters;

        return distance;
    }
}