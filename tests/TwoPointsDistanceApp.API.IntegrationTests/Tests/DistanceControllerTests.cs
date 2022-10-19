using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using TwoPointsDistanceApp.API.IntegrationTests.Common.EndpointOperations;
using TwoPointsDistanceApp.API.IntegrationTests.Common.Factories.Requests;
using TwoPointsDistanceApp.API.IntegrationTests.Setup;
using TwoPointsDistanceApp.Application.Common.DistanceCalculators;
using TwoPointsDistanceApp.Application.Features.Distance.Queries.DTOs;
using TwoPointsDistanceApp.Domain.ValueObjects;
using Xunit;

namespace TwoPointsDistanceApp.API.IntegrationTests.Tests;

public class DistanceControllerTests : IClassFixture<TestWebApplicationFactory<Program>>
{
    private readonly TestWebApplicationFactory<Program> _factory;
    private readonly HttpClient _httpClient;

    public DistanceControllerTests(TestWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _httpClient = _factory.HttpClient;
    }

    [Theory]
    [InlineData(DistanceCalculationFormula.SphericalLawOfCosines)]
    [InlineData(DistanceCalculationFormula.Haversine)]
    [InlineData(DistanceCalculationFormula.EquirectangularApproximation)]
    public async Task ShouldCalculateDistance(DistanceCalculationFormula calculationFormula)
    {
        //Arrange
        var request = CalculateDistanceRequestsFactory.Create(calculationFormula);
        var distanceCalculator = GetCalculatorFor(calculationFormula);
        var expectedValue = distanceCalculator.Calculate(request.PointA.ToDomainContract(), request.PointB.ToDomainContract());

        //Act
        var (response, result) = await _httpClient.CalculateDistance(request);

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        result.Meters.Should().Be(expectedValue.Meters);
    }

    private static IDistanceCalculator GetCalculatorFor(DistanceCalculationFormula calculationFormula) =>
        calculationFormula switch
        {
            DistanceCalculationFormula.Haversine => new HaversineDistanceCalculator(),
            DistanceCalculationFormula.EquirectangularApproximation => new EquirectangularApproximationDistanceCalculator(),
            DistanceCalculationFormula.SphericalLawOfCosines => new SphericalLawOfCosinesDistanceCalculator(),
            _ => throw new ArgumentOutOfRangeException(nameof(calculationFormula), calculationFormula, null)
        };
}