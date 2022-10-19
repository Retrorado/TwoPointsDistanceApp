namespace TwoPointsDistanceApp.Domain.Exceptions;

internal class InvalidLongitudeValueException : DomainException
{
    public InvalidLongitudeValueException(double value) : base($"Invalid longitude value: {value}")
    {
    }
}