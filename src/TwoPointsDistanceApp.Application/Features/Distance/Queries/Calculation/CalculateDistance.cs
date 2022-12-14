using TwoPointsDistanceApp.Application.Features.Distance.Queries.DTOs;
using TwoPointsDistanceApp.Domain.ValueObjects;

namespace TwoPointsDistanceApp.Application.Features.Distance.Queries.Calculation;

public record CalculateDistance(Coordinates PointA, Coordinates PointB, DistanceCalculationFormula Formula);