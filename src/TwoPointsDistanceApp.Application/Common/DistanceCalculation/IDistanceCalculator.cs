namespace TwoPointsDistanceApp.Application.Common.DistanceCalculation;

public interface IDistanceCalculator
{
    double Calculate(double latitude, double longitude);
}