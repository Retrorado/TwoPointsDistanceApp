namespace TwoPointsDistanceApp.Domain.Exceptions;

internal class InvalidLatitudeValueException : DomainException
{
    public InvalidLatitudeValueException(double value) : base($"Invalid latitude value: {value}")
    {
    }
}