namespace TwoPointsDistanceApp.Domain.ValueObjects;

public record Degrees
{
    public double Value { get; }

    private Degrees(double value)
    {
        Value = value;
    }

    public static Degrees Create(double value) => new(value);

    public Radians ToRadians() => Radians.FromDegrees(this);

    public static Degrees FromRadians(Radians radians) => new(radians.Value / Math.PI * 180.0);

    public static Degrees operator +(Degrees degrees, Degrees other)
    {
        return new Degrees(degrees.Value + other.Value);
    }

    public static Degrees operator -(Degrees degrees, Degrees other)
    {
        return new Degrees(degrees.Value - other.Value);
    }
}