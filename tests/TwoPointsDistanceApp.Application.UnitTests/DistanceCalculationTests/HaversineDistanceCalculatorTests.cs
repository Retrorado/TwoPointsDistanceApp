using FluentAssertions;
using TwoPointsDistanceApp.Application.Common.DistanceCalculators;
using TwoPointsDistanceApp.Domain.ValueObjects;
using Xunit;

namespace TwoPointsDistanceApp.Application.UnitTests.DistanceCalculationTests;

public class HaversineDistanceCalculatorTests
{
    private readonly IDistanceCalculator _sut;

    public HaversineDistanceCalculatorTests()
    {
        _sut = new HaversineDistanceCalculator();
    }

    private LengthUnit Act(Coordinates pointA, Coordinates pointB) => _sut.Calculate(pointA, pointB);

    [Fact]
    public void ShouldCalculateDistance()
    {
        //Arrange
        var pointA = Coordinates.Create(53.297975, -69.372663);
        var pointB = Coordinates.Create(55.876921, -71.440440);

        //Act
        var result = Act(pointA, pointB);

        //Assert
        result.Meters.Should().BeGreaterThan(0);
    }
}