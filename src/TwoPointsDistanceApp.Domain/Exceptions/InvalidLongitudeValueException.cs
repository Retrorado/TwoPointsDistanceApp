namespace TwoPointsDistanceApp.Domain.Exceptions;

internal class InvalidLongitudeValueException : Exception
{
    public InvalidLongitudeValueException(double value) : base($"Invalid longitude value: {value}")
    {
    }
}