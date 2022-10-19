using TwoPointsDistanceApp.Application.Features.Distance.Queries.DTOs;
using TwoPointsDistanceApp.Controllers.Requests;

namespace TwoPointsDistanceApp.API.IntegrationTests.Common.Factories.Requests;

public static class CalculateDistanceRequestsFactory
{
    public static CalculateDistanceRequest Create(DistanceCalculationFormula formula = DistanceCalculationFormula.Default)
    {
        return new CalculateDistanceRequest(
            new CoordinatesDto(53.297975, -6.372663),
            new CoordinatesDto(41.385101, -81.440440),
            formula);
    }
}