using TwoPointsDistanceApp.Domain.ValueObjects;

namespace TwoPointsDistanceApp.Application.Common.DistanceCalculation;

public interface IDistanceCalculator
{
    LengthUnit Calculate(Coordinates pointA, Coordinates pointB);
}