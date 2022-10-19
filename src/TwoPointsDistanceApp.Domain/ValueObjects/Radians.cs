namespace TwoPointsDistanceApp.Domain.ValueObjects;

public record Radians
{
    public double Value { get; }

    private Radians(double value)
    {
        Value = value;
    }

    public static Radians Create(double value) => new(value);

    public static Radians FromDegrees(Degrees degrees) => new(degrees.Value * Math.PI / 180.0);

    public Degrees ToDegrees() => Degrees.FromRadians(this);
}