using TwoPointsDistanceApp.Application.Features.Distance.Queries.Calculation;
using TwoPointsDistanceApp.Application.Features.Distance.Queries.DTOs;

namespace TwoPointsDistanceApp.Controllers.Requests;

public record CalculateDistanceRequest(CoordinatesDto PointA, CoordinatesDto PointB, DistanceCalculationFormula Formula)
{
    internal CalculateDistance ToCommand() => new(PointA.ToDomainContract(), PointB.ToDomainContract(), Formula);
}