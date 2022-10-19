using TwoPointsDistanceApp.Domain.ValueObjects;

namespace TwoPointsDistanceApp.Application.Features.Distance.Queries.DTOs.Extensions;

public static class LengthUnitMapperExtensions
{
    public static LengthUnitDto ToApiContract(this LengthUnit lengthUnit)
        => new(lengthUnit.Meters, lengthUnit.Kilometers, lengthUnit.Miles);
}