using TwoPointsDistanceApp.Domain.Exceptions;

namespace TwoPointsDistanceApp.Domain.ValueObjects;

public record Coordinates
{
    private const double MinLatitudeValue = -90;
    private const double MaxLatitudeValue = 90;
    private const double MinLongitudeValue = -180;
    private const double MaxLongitudeValue = 180;

    public Degrees Latitude { get; }
    public Degrees Longitude { get; }

    private Coordinates(double latitude, double longitude)
    {
        if (latitude is < MinLatitudeValue or > MaxLatitudeValue)
        {
            throw new InvalidLatitudeValueException(latitude);
        }

        if (longitude is < MinLongitudeValue or > MaxLongitudeValue)
        {
            throw new InvalidLongitudeValueException(longitude);
        }

        Latitude = Degrees.Create(latitude);
        Longitude = Degrees.Create(longitude);
    }

    public static Coordinates Create(double latitude, double longitude) => new(latitude, longitude);
}