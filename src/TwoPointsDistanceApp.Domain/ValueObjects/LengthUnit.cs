using TwoPointsDistanceApp.Domain.Exceptions;

namespace TwoPointsDistanceApp.Domain.ValueObjects;

public record LengthUnit
{
    private const int MinMetersValue = 0;

    public static readonly LengthUnit Zero = new(MinMetersValue);

    public double Meters { get; }

    private LengthUnit(double meters)
    {
        if (meters is < MinMetersValue)
        {
            throw new InvalidLengthValueException(meters);
        }

        Meters = meters;
    }

    public static LengthUnit FromMeters(double meters) => new(meters);

    public double Kilometers() => Meters / 1000;

    public double Miles() => Meters * 0.0006213712;

    public static LengthUnit operator +(LengthUnit lengthUnit, LengthUnit other)
    {
        return new LengthUnit(lengthUnit.Meters + other.Meters);
    }

    public static LengthUnit operator -(LengthUnit lengthUnit, LengthUnit other)
    {
        return new LengthUnit(lengthUnit.Meters - other.Meters);
    }
}