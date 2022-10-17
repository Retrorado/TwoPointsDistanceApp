using TwoPointsDistanceApp.Application.Features.Distance.Commands.Calculation;

namespace TwoPointsDistanceApp.Controllers.Requests;

public record CalculateDistanceRequest(double Latitude, double Longitude)
{
    internal CalculateDistance ToCommand()
    {
        return new CalculateDistance(Latitude, Longitude);
    }
}