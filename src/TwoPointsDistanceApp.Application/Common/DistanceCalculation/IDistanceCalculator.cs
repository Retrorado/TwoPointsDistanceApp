using TwoPointsDistanceApp.Domain.ValueObjects;

namespace TwoPointsDistanceApp.Application.Common.DistanceCalculation;

public interface IDistanceCalculator
{
    double Calculate(Coordinates pointA, Coordinates pointB);
}