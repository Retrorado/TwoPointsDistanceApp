using FluentAssertions;
using TwoPointsDistanceApp.Application.Common.DistanceCalculation;
using TwoPointsDistanceApp.Domain.ValueObjects;
using Xunit;

namespace TwoPointsDistanceApp.Application.UnitTests.DistanceCalculationTests;

public class SphericalLawOfCosinesDistanceCalculatorTests
{
    private readonly IDistanceCalculator _sut;

    public SphericalLawOfCosinesDistanceCalculatorTests()
    {
        _sut = new SphericalLawOfCosinesDistanceCalculator();
    }

    private LengthUnit Act(Coordinates pointA, Coordinates pointB) => _sut.Calculate(pointA, pointB);

    [Fact]
    public void ShouldCalculateDistance()
    {
        //Arrange
        var pointA = Coordinates.Create(53.297975, -6.372663);
        var pointB = Coordinates.Create(41.385101, -81.440440);

        //Act
        var result = Act(pointA, pointB);

        //Assert
        result.Meters.Should().BeGreaterThan(0);
    }
}