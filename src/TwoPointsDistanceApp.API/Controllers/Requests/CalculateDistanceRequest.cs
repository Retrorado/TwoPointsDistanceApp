using TwoPointsDistanceApp.Application.Features.Distance.Queries.Calculation;
using TwoPointsDistanceApp.Domain.ValueObjects;

namespace TwoPointsDistanceApp.Controllers.Requests;

public record CalculateDistanceRequest(Coordinates PointA, Coordinates PointB)
{
    internal CalculateDistance ToCommand() => new(PointA, PointB);
}