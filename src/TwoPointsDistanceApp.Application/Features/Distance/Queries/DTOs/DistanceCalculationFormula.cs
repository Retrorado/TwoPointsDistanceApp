namespace TwoPointsDistanceApp.Application.Features.Distance.Queries.DTOs;

public enum DistanceCalculationFormula
{
    Default = 0,
    Haversine = 1,
    SphericalLawOfCosines = 2,
    EquirectangularApproximation = 3,
}