namespace TwoPointsDistanceApp.Domain.Exceptions;

internal class InvalidLatitudeValueException : Exception
{
    public InvalidLatitudeValueException(double value) : base($"Invalid latitude value: {value}")
    {
    }
}