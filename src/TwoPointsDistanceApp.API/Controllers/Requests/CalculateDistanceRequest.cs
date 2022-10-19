using TwoPointsDistanceApp.Application.Features.Distance.Queries.Calculation;

namespace TwoPointsDistanceApp.Controllers.Requests;

public record CalculateDistanceRequest(CoordinatesDto PointA, CoordinatesDto PointB)
{
    internal CalculateDistance ToCommand() => new(PointA.ToDomainContract(), PointB.ToDomainContract());
}